using System.Collections.Generic;
using Domain.Base;

namespace Application.Base
{
	public interface IGetItemListQuery<TEntity>
	{
		IEnumerable<ListItem> Execute();
	}
}