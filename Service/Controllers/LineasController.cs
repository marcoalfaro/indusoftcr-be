using System.Collections.Generic;
using Application.Lineas;
using Application.Generic;
using Application.Interfaces;
using Domain;
using Domain.Base;
using Microsoft.EntityFrameworkCore;

namespace Service.Controllers
{
    public class LineasController: ControllerBase<Linea, LineaModel>
    {
	    private readonly IGetListQuery<Linea, LineaModel> allQuery;
	    private readonly IGetActiveListQuery<Linea, LineaModel> activeQuery;
	    private readonly IGetItemListQuery<Linea> allItemsQuery;
	    private readonly IGetDetailQuery<Linea, LineaModel> detailsQuery;
		public override DbSet<Linea> DbSet => DataService.Lineas;

		public LineasController(
		    IGetListQuery<Linea, LineaModel> allQuery,
		    IGetActiveListQuery<Linea, LineaModel> activeQuery,
		    IGetItemListQuery<Linea> allItemsQuery,
		    IGetDetailQuery<Linea, LineaModel> detailsQuery,
			IDatabaseService databaseService
	    ): base(databaseService)
	    {
		    this.allQuery = allQuery;
		    this.activeQuery = activeQuery;
		    this.allItemsQuery = allItemsQuery;
		    this.detailsQuery = detailsQuery;
	    }

	    public IEnumerable<LineaModel> Get()
	    {
		    return allQuery.Execute();
	    }

	    public IEnumerable<ListItem> GetItemList()
	    {
		    return allItemsQuery.Execute();
	    }

	    public IEnumerable<LineaModel> GetActive()
	    {
		    return activeQuery.Execute();
	    }

	    public LineaModel GetDetail(int id)
	    {
		    return detailsQuery.Execute(id);
	    }
    }
}
