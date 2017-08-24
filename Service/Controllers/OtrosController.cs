using System.Collections;
using System.Linq;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Service.Controllers
{
	[Route("api/[controller]")]
	public class OtrosController: Controller
	{
		//private IGetListQuery<Cliente, ClienteModel> q;
		private IDatabaseService db;

		public OtrosController(/*IGetListQuery<Cliente, ClienteModel> q, */IDatabaseService db)
		{
			this.db = db;
			//this.q = q;
		}

		[HttpGet]
		public IEnumerable Get()
		{
			var clientes = db.Clientes.Take(3).ToList();
			var empresas = db.Precios.Take(3).ToList();
			//var empresaConfigs = db.EmpresaConfigs.Take(3).ToList();

			var q = db.Cotizaciones.Take(3);
			var cots = q.ToList();
			return clientes;
		}

	}
}
