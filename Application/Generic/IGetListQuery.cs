using System.Collections.Generic;

namespace Application.Generic
{
    public interface IGetListQuery<TEntity, out TModel>
    {
	    IEnumerable<TModel> Execute();
    }
}
