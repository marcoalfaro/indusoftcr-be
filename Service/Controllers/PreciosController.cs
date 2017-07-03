using System.Collections.Generic;
using Application.Precios;
using Application.Generic;
using Domain;

namespace Service.Controllers
{
    public class PreciosController
    {
	    private readonly IGetListQuery<Precio, PrecioModel> allQuery;
	    private readonly IGetDetailQuery<Precio, PrecioModel> detailsQuery;
		
	    public PreciosController(
		    IGetListQuery<Precio, PrecioModel> allQuery,
		    IGetDetailQuery<Precio, PrecioModel> detailsQuery
	    )
	    {
		    this.allQuery = allQuery;
		    this.detailsQuery = detailsQuery;
	    }

	    public IEnumerable<PrecioModel> Get()
	    {
		    return allQuery.Execute();
	    }
		
	    public PrecioModel GetDetail(int id)
	    {
		    return detailsQuery.Execute(id);
	    }
	}
}
