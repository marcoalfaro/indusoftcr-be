using System.Collections.Generic;
using Application.Base;
using Application.Interfaces;
using Application.Materiales;
using Domain;
using Domain.Base;
using Microsoft.EntityFrameworkCore;

namespace Service.Controllers
{
    public class MaterialesController: ControllerBase<Material, MaterialModel>
	{
	    private readonly IGetActiveListQuery<Material, MaterialModel> activeQuery;
	    private readonly IGetItemListQuery<Material> allItemsQuery;
	    public override DbSet<Material> DbSet => DataService.Materiales;

		public MaterialesController(
		    IGetListQuery<Material, MaterialModel> allQuery,
		    IGetActiveListQuery<Material, MaterialModel> activeQuery,
		    IGetItemListQuery<Material> allItemsQuery,
		    IGetDetailQuery<Material, MaterialModel> detailsQuery,
		    IDatabaseService databaseService
		) : base(allQuery, detailsQuery, databaseService)
		{
		    this.activeQuery = activeQuery;
		    this.allItemsQuery = allItemsQuery;
	    }

	    public IEnumerable<ListItem> GetItemList()
	    {
		    return allItemsQuery.Execute();
	    }

	    public IEnumerable<MaterialModel> GetActive()
	    {
		    return activeQuery.Execute();
	    }
	}
}
