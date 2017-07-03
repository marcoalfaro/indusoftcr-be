using System.Collections.Generic;
using Application.Cotizaciones;
using Application.Generic;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace Service.Controllers
{
    public class CotizacionesController: Controller
    {
	    private readonly IGetListQuery<Cotizacion, CotizacionModel> allQuery;
	    private readonly IGetDetailQuery<Cotizacion, CotizacionModel> detailsQuery;


	    public CotizacionesController(
		    IGetListQuery<Cotizacion, CotizacionModel> allQuery,
		    IGetDetailQuery<Cotizacion, CotizacionModel> detailsQuery
	    )
	    {
		    this.allQuery = allQuery;
		    this.detailsQuery = detailsQuery;
	    }

	    public IEnumerable<CotizacionModel> Get()
	    {
		    return allQuery.Execute();
	    }
		
	    public CotizacionModel GetDetail(int id)
	    {
		    return detailsQuery.Execute(id);
	    }
	}
}
