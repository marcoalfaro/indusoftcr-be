using System.Collections.Generic;
using Application;
using Application.Clientes;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace Service.Controllers
{
	public class ClientesController: Controller
    {
	    private readonly IGetListQuery<Cliente, ClienteModel> query;
	    
		public ClientesController(IGetListQuery<Cliente, ClienteModel> query)
	    {
		    this.query = query;
	    }
		
		public IEnumerable<ClienteModel> Get()
	    {
		    return query.Execute();
	    }
	}
}
