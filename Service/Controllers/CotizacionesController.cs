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

	    public IActionResult Get()
	    {
		    return Ok(allQuery.Execute());
	    }

	    public IActionResult Put([FromBody] CotizacionModel updated)
	    {
		    if (!ModelState.IsValid)
			    return BadRequest();


		    return Ok();
	    }

		//public virtual HttpResponseMessage Put([FromBody] TViewModel updated)
		//{
		//	var result = DbSet.Update(updated);
		//	if (result == null)
		//		return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Record was not found in database");
		//	DbContext.SaveChanges();
		//	return Request.CreateResponse(HttpStatusCode.OK);
		//}

		public IActionResult GetDetail(int id)
	    {
		    return Ok(detailsQuery.Execute(id));
	    }
	}
}
