using Application.Base;
using Application.Interfaces;
using Application.Vendedores;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Service.Controllers
{
	public class VendedoresController: ControllerBase<Vendedor, VendedorModel>
    {
	    private readonly IGetActiveListQuery<Vendedor, VendedorModel> activeQuery;
	    private readonly IGetItemListQuery<Vendedor> allItemsQuery;
	    public override DbSet<Vendedor> DbSet => DataService.Vendedores;
		
		public VendedoresController(
			IGetListQuery<Vendedor, VendedorModel> allQuery,
			IGetActiveListQuery<Vendedor, VendedorModel> activeQuery,
			IGetItemListQuery<Vendedor> allItemsQuery,
			IGetDetailQuery<Vendedor, VendedorModel> detailsQuery,
			IDatabaseService databaseService
		) : base(allQuery, detailsQuery, databaseService)
		{   
		    this.activeQuery = activeQuery;
		    this.allItemsQuery = allItemsQuery;
	    }

		public IActionResult GetItemList()
	    {
		    return Ok(allItemsQuery.Execute());
	    }

	    public IActionResult GetActive()
	    {
		    return Ok(activeQuery.Execute());
	    }
	}
}
