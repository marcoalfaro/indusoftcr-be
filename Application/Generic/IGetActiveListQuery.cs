using System.Collections.Generic;

namespace Application.Generic
{
	public interface IGetActiveListQuery<TEntity, out TModel>
	{
		IEnumerable<TModel> Execute();
	}
}