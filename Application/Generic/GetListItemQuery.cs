using System.Collections.Generic;
using System.Linq;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Base;

namespace Application.Generic
{
	public class GetListItemQuery<TEntity> : IGetItemListQuery<TEntity>
		where TEntity : ActivableEntity
	{
		protected readonly IDatabaseService Db;
		protected readonly IConfigurationProvider MapperConfiguration;

		public GetListItemQuery(IDatabaseService db, IConfigurationProvider mapperConfiguration)
		{
			Db = db;
			MapperConfiguration = mapperConfiguration;
		}

		public virtual IEnumerable<ListItem> Execute()
		{
			return Db.GetDbSet<TEntity>().Where(x => x.Activo).ProjectTo<ListItem>(MapperConfiguration);
		}
	}
}