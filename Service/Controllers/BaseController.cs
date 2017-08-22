using System.Linq;
using Application.Base;
using Application.Interfaces;
using AutoMapper;
using Domain.Base;
using Microsoft.ApplicationInsights.AspNetCore.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Service.Controllers
{
	public abstract class ControllerBase<TEntity, TModel>: Controller
		where TEntity : ApplicationEntity
		where TModel : ApplicationModel, new()
	{
		public IDatabaseService DataService { get; set; }
		public abstract DbSet<TEntity> DbSet { get; }
		private readonly IGetListQuery<TEntity, TModel> allQuery;
		private readonly IGetDetailQuery<TEntity, TModel> detailsQuery;

		protected ControllerBase(
			IGetListQuery<TEntity, TModel> allQuery,
			IGetDetailQuery<TEntity, TModel> detailsQuery,
			IDatabaseService dataService)
		{
			DataService = dataService;
			this.allQuery = allQuery;
			this.detailsQuery = detailsQuery;
		}

		public IActionResult Get()
		{
			return Ok(allQuery.Execute());
		}

		public IActionResult GetDetail(int id)
		{
			return Ok(detailsQuery.Execute(id));
		}

		[HttpPost("[controller]")]
		public virtual IActionResult Post([FromBody] TModel newModel)
		{
			if (newModel == null || !ModelState.IsValid)
				return BadRequest();

			var entity = Mapper.Map<TModel, TEntity>(newModel);
			DbSet.Add(entity);

			DataService.Save();
			return Created(Request?.GetUri() + "/" + entity.Id, Mapper.Map<TEntity, TModel>(entity));
		}

		[HttpPut("[controller]")]
		public virtual IActionResult Put([FromBody] TModel model)
		{
			var entity = DbSet.FirstOrDefault(x => x.Id == model.Id);
			if (entity == null)
				return NotFound();
			
			model.UpdateEntityFields(entity);
			DataService.Save();
			
			return Ok(Mapper.Map<TEntity, TModel>(entity));
		}
	}
}
