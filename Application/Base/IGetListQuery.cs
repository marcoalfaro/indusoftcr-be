using System.Collections.Generic;

namespace Application.Base
{
    public interface IGetListQuery<TEntity, out TModel>
    {
	    IEnumerable<TModel> Execute();
    }
}
