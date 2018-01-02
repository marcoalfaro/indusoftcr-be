using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using Application.Base;
using Application.Lineas;
using Application.Interfaces;
using Domain;
using Domain.Base;
using Microsoft.EntityFrameworkCore;

namespace Service.Controllers
{
    public class LineasController: ControllerBase<Linea, LineaModel>
    {
	    private readonly IGetActiveListQuery<Linea, LineaModel> activeQuery;
	    private readonly IGetItemListQuery<Linea> allItemsQuery;
		public override DbSet<Linea> DbSet => DataService.Lineas;

		public LineasController(
		    IGetListQuery<Linea, LineaModel> allQuery,
		    IGetActiveListQuery<Linea, LineaModel> activeQuery,
		    IGetItemListQuery<Linea> allItemsQuery,
		    IGetDetailQuery<Linea, LineaModel> detailsQuery,
			IDatabaseService databaseService
	    ): base(allQuery, detailsQuery, databaseService)
	    {
		    this.activeQuery = activeQuery;
		    this.allItemsQuery = allItemsQuery;
	    }
		
	    //public IActionResult GetItemList()
	    //{
	    //    try
	    //    {
	    //        return Ok(allItemsQuery.Execute());
                
	    //    }
	    //    catch (Exception ex)
	    //    {
	    //        return BadRequest(ex.Message);
	    //    }
	    //}

	    public IEnumerable<LineaModel> GetActive()
	    {
		    return activeQuery.Execute();
	    }
    }
}
