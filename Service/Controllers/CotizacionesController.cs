using Application.Base;
using Application.Cotizaciones;
using Application.Interfaces;
using Domain;
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
		

		//public virtual HttpResponseMessage Put([FromBody] TViewModel updated)
		//{
		//	var result = DbSet.Update(updated);
		//	if (result == null)
		//		return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Record was not found in database");
		//	DbContext.SaveChanges();
		//	return Request.CreateResponse(HttpStatusCode.OK);
		//}
	}
}
