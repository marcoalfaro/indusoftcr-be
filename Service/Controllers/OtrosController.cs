using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Application.Clientes;
using Application.Generic;
using Application.Interfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace Service.Controllers
{
	[Route("api/[controller]")]
	public class OtrosController: Controller
	{
		private IGetListQuery<Cliente, ClienteModel> db;

		public OtrosController(IGetListQuery<Cliente, ClienteModel> db)
		{
			this.db = db;
		}

		[HttpGet]
		public IEnumerable<ClienteModel> Get()
		{
			var list = db.Execute();
			return list;
		}

	}
}
