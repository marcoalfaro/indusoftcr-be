using System;
using Application.Base;
using Application.Cotizaciones;
using Application.Interfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Service.Controllers
{
    public class CotizacionesController: ControllerBase<Cotizacion, CotizacionModel>
    {
	    public override DbSet<Cotizacion> DbSet => DataService.Cotizaciones;

		public CotizacionesController(
		    IGetListQuery<Cotizacion, CotizacionModel> allQuery,
		    IGetDetailQuery<Cotizacion, CotizacionModel> detailsQuery,
			IDatabaseService databaseService
		) : base(allQuery, detailsQuery, databaseService)
		{
	    }

	    protected override bool IsModelValid(CotizacionModel model)
	    {
		    return base.IsModelValid(model) || model.Cliente != null;
	    }
		
	    public override IActionResult Post([FromBody] CotizacionModel newModel)
	    {
		    newModel.Fecha = newModel.FecRegistro = DateTime.Now;
			return base.Post(newModel);
	    }
	}
}
