using System.Collections.Generic;
using Application.Generic;
using Application.Vendedores;
using Domain;
using Domain.Base;
using Microsoft.AspNetCore.Mvc;

namespace Service.Controllers
{
	public class VendedoresController: Controller
    {
	    private readonly IGetListQuery<Vendedor, VendedorModel> allQuery;
	    private readonly IGetActiveListQuery<Vendedor, VendedorModel> activeQuery;
	    private readonly IGetItemListQuery<Vendedor> allItemsQuery;
	    private readonly IGetDetailQuery<Vendedor, VendedorModel> detailsQuery;


		public VendedoresController(
			IGetListQuery<Vendedor, VendedorModel> allQuery,
			IGetActiveListQuery<Vendedor, VendedorModel> activeQuery,
			IGetItemListQuery<Vendedor> allItemsQuery,
			IGetDetailQuery<Vendedor, VendedorModel> detailsQuery
			)
	    {
		    this.allQuery = allQuery;
		    this.activeQuery = activeQuery;
		    this.allItemsQuery = allItemsQuery;
		    this.detailsQuery = detailsQuery;
	    }
		
		public IEnumerable<VendedorModel> Get()
	    {
		    return allQuery.Execute();
	    }
	    public IEnumerable<ListItem> GetItemList()
	    {
		    return allItemsQuery.Execute();
	    }

		public IEnumerable<VendedorModel> GetActive()
		{
			return activeQuery.Execute();
		}

	    public VendedorModel GetDetail(int id)
	    {
		    return detailsQuery.Execute(id);
	    }
	}
}
