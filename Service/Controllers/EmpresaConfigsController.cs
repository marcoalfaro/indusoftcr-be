using Application.EmpresaConfigs;
using Application.Generic;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace Service.Controllers
{
	public class EmpresaConfigsController : Controller
	{
		private readonly IGetDetailQuery<EmpresaConfig, EmpresaConfigModel> detailsQuery;


		public EmpresaConfigsController(
			IGetDetailQuery<EmpresaConfig, EmpresaConfigModel> detailsQuery
		)
		{
			this.detailsQuery = detailsQuery;
		}

		public EmpresaConfigModel GetDetail(int id)
		{
			return detailsQuery.Execute(id);
		}
	}
}