using System.Collections.Generic;
using Domain.Base;

namespace Application.Generic
{
	public interface IGetItemListQuery<TEntity>
	{
		IEnumerable<ListItem> Execute();
	}
}