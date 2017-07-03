using System.Collections.Generic;
using Application.Generic;
using Application.Materiales;
using Domain;
using Domain.Base;

namespace Service.Controllers
{
    public class MaterialesController
    {
	    private readonly IGetListQuery<Material, MaterialModel> allQuery;
	    private readonly IGetActiveListQuery<Material, MaterialModel> activeQuery;
	    private readonly IGetItemListQuery<Material> allItemsQuery;
	    private readonly IGetDetailQuery<Material, MaterialModel> detailsQuery;


	    public MaterialesController(
		    IGetListQuery<Material, MaterialModel> allQuery,
		    IGetActiveListQuery<Material, MaterialModel> activeQuery,
		    IGetItemListQuery<Material> allItemsQuery,
		    IGetDetailQuery<Material, MaterialModel> detailsQuery
	    )
	    {
		    this.allQuery = allQuery;
		    this.activeQuery = activeQuery;
		    this.allItemsQuery = allItemsQuery;
		    this.detailsQuery = detailsQuery;
	    }

	    public IEnumerable<MaterialModel> Get()
	    {
		    return allQuery.Execute();
	    }

	    public IEnumerable<ListItem> GetItemList()
	    {
		    return allItemsQuery.Execute();
	    }

	    public IEnumerable<MaterialModel> GetActive()
	    {
		    return activeQuery.Execute();
	    }

	    public MaterialModel GetDetail(int id)
	    {
		    return detailsQuery.Execute(id);
	    }
	}
}
