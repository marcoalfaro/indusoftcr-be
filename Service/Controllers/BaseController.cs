//using System.Collections.Generic;
//using Application;
//using Domain.Base;
//using Microsoft.AspNetCore.Mvc;

//namespace Service.Controllers
//{
//	[Route("api/[controller]")]
//	public abstract class BaseController<TEntity, TViewModel> : Controller
//		where TEntity : BaseEntity
//		where TViewModel : BaseModel
//	{
		
//		public IGetListQuery<TEntity, TViewModel> GetListQuery { get; set; }

//		[HttpGet]
//		public virtual IEnumerable<TViewModel> GetAll()
//		{
//			return GetListQuery.Execute();
//		}

//		//public virtual TViewModel Get(int id)
//		//{
//		//	var query = OnCreatingQueryGet(DbSet.AsQueryable());
//		//	var entity = query.SingleOrDefault(x => x.Id == id);
//		//	if (entity == null)
//		//	{
//		//		return null;
//		//	}
//		//	var viewModel = Activator.CreateInstance(typeof(TViewModel), entity) as TViewModel;
//		//	return viewModel;
//		//}
//		//public virtual HttpResponseMessage Post([FromBody] TViewModel newViewModel)
//		//{
//		//	if (newViewModel == null)
//		//	{
//		//		return Request.CreateResponse(HttpStatusCode.InternalServerError);
//		//	}
//		//	DbSet.Insert(newViewModel);
//		//	DbContext.SaveChanges();
//		//	return Request.CreateResponse(HttpStatusCode.OK);
//		//}

//		//public virtual HttpResponseMessage Put([FromBody] TViewModel updated)
//		//{
//		//	var result = DbSet.Update(updated);
//		//	if (result == null)
//		//		return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Record was not found in database");
//		//	DbContext.SaveChanges();
//		//	return Request.CreateResponse(HttpStatusCode.OK);
//		//}

//		//public virtual IHttpActionResult Delete(int id)
//		//{
//		//	try
//		//	{
//		//		var entity = DbSet.Find(id);
//		//		if (entity == null)
//		//			return NotFound();

//		//		DbSet.Delete(entity);
//		//		DbContext.SaveChanges();
//		//		return Ok();
//		//	}
//		//	catch (Exception e)
//		//	{
//		//		return InternalServerError(new Exception("Item can not be deleted"));
//		//	}
//		//}
//		//protected virtual IQueryable<TEntity> OnCreatingQueryGet(IQueryable<TEntity> query)
//		//{
//		//	return AddIncludes(query);
//		//}

//		//protected virtual IQueryable<TEntity> OnCreatingQueryGetAll(IQueryable<TEntity> query)
//		//{
//		//	return AddIncludes(query);
//		//}

//		//protected virtual IQueryable<TEntity> AddIncludes(IQueryable<TEntity> query)
//		//{
//		//	return query;
//		//}
//	}
//}