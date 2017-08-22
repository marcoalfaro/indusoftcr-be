using System.Collections.Generic;

namespace Application.Base
{
	public interface IGetActiveListQuery<TEntity, out TModel>
	{
		IEnumerable<TModel> Execute();
	}
}