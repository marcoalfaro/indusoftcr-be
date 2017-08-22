using System.Collections.Generic;
using Application.Base;
using Application.Clientes;
using Application.Interfaces;
using Domain;
using Domain.Base;
using Microsoft.EntityFrameworkCore;

namespace Service.Controllers
{
	public class ClientesController: ControllerBase<Cliente, ClienteModel>
	{
	    private readonly IGetActiveListQuery<Cliente, ClienteModel> activeQuery;
	    private readonly IGetItemListQuery<Cliente> allItemsQuery;
		public override DbSet<Cliente> DbSet => DataService.Clientes;

		public ClientesController(
			IGetListQuery<Cliente, ClienteModel> allQuery,
			IGetActiveListQuery<Cliente, ClienteModel> activeQuery,
			IGetItemListQuery<Cliente> allItemsQuery,
			IGetDetailQuery<Cliente, ClienteModel> detailsQuery,
			IDatabaseService databaseService
		) : base(allQuery, detailsQuery, databaseService)
		{
		    this.activeQuery = activeQuery;
		    this.allItemsQuery = allItemsQuery;
	    }
		
	    public IEnumerable<ListItem> GetItemList()
	    {
		    return allItemsQuery.Execute();
	    }

		public IEnumerable<ClienteModel> GetActive()
		{
			return activeQuery.Execute();
		}
	}
}
