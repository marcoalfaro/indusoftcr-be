using System.Collections.Generic;
using Application.TipoCambios;
using Application.Generic;
using Domain;

namespace Service.Controllers
{
    public class TipoCambiosController
    {
	    private readonly IGetListQuery<TipoCambio, TipoCambioModel> allQuery;
	    private readonly IGetDetailQuery<TipoCambio, TipoCambioModel> detailsQuery;
		
	    public TipoCambiosController(
		    IGetListQuery<TipoCambio, TipoCambioModel> allQuery,
		    IGetDetailQuery<TipoCambio, TipoCambioModel> detailsQuery
	    )
	    {
		    this.allQuery = allQuery;
		    this.detailsQuery = detailsQuery;
	    }

	    public IEnumerable<TipoCambioModel> Get()
	    {
		    return allQuery.Execute();
	    }
		
	    public TipoCambioModel GetDetail(int id)
	    {
		    return detailsQuery.Execute(id);
	    }
	}
}
