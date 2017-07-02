using System.Collections.Generic;
using Application.Clientes;
using Application.Generic;
using Domain;
using Domain.Base;
using Microsoft.AspNetCore.Mvc;

namespace Service.Controllers
{
	public class ClientesController: Controller
    {
	    private readonly IGetListQuery<Cliente, ClienteModel> allQuery;
	    private readonly IGetActiveListQuery<Cliente, ClienteModel> activeQuery;
	    private readonly IGetItemListQuery<Cliente> allItemsQuery;
	    private readonly IGetDetailQuery<Cliente, ClienteModel> detailsQuery;


		public ClientesController(
			IGetListQuery<Cliente, ClienteModel> allQuery,
			IGetActiveListQuery<Cliente, ClienteModel> activeQuery,
			IGetItemListQuery<Cliente> allItemsQuery,
			IGetDetailQuery<Cliente, ClienteModel> detailsQuery
			)
	    {
		    this.allQuery = allQuery;
		    this.activeQuery = activeQuery;
		    this.allItemsQuery = allItemsQuery;
		    this.detailsQuery = detailsQuery;
	    }
		
		public IEnumerable<ClienteModel> Get()
	    {
		    return allQuery.Execute();
	    }
	    public IEnumerable<ListItem> GetItemList()
	    {
		    return allItemsQuery.Execute();
	    }

		public IEnumerable<ClienteModel> GetActive()
		{
			return activeQuery.Execute();
		}

	    public ClienteModel GetDetail(int id)
	    {
		    return detailsQuery.Execute(id);
	    }
	}
}
