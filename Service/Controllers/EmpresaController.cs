using System.Collections.Generic;
using Application.Base;
using Application.Empresas;
using Domain;
using Domain.Base;

namespace Service.Controllers
{
    public class EmpresasController
    {
	    private readonly IGetListQuery<Empresa, EmpresaModel> allQuery;
	    private readonly IGetActiveListQuery<Empresa, EmpresaModel> activeQuery;
	    private readonly IGetItemListQuery<Empresa> allItemsQuery;
	    private readonly IGetDetailQuery<Empresa, EmpresaModel> detailsQuery;


	    public EmpresasController(
		    IGetListQuery<Empresa, EmpresaModel> allQuery,
		    IGetActiveListQuery<Empresa, EmpresaModel> activeQuery,
		    IGetItemListQuery<Empresa> allItemsQuery,
		    IGetDetailQuery<Empresa, EmpresaModel> detailsQuery
	    )
	    {
		    this.allQuery = allQuery;
		    this.activeQuery = activeQuery;
		    this.allItemsQuery = allItemsQuery;
		    this.detailsQuery = detailsQuery;
	    }

	    public IEnumerable<EmpresaModel> Get()
	    {
		    return allQuery.Execute();
	    }

	    public IEnumerable<ListItem> GetItemList()
	    {
		    return allItemsQuery.Execute();
	    }

	    public IEnumerable<EmpresaModel> GetActive()
	    {
		    return activeQuery.Execute();
	    }

	    public EmpresaModel GetDetail(int id)
	    {
		    return detailsQuery.Execute(id);
	    }
	}
}
