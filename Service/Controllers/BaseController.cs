using Application.Generic;
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

		protected ControllerBase(IDatabaseService dataService)
		{
			DataService = dataService;
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
	}
}
