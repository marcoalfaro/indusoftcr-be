using System.Collections.Generic;

namespace Application
{
    public interface IGetListQuery<TEntity, out TModel>
    {
	    IEnumerable<TModel> Execute();
    }


	//public interface IGetListQuery
	//{
	//}
}
