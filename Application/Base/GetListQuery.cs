using System.Collections.Generic;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Base;

namespace Application.Base
{
	public class GetListQuery<TEntity, TModel> : IGetListQuery<TEntity, TModel>
		where TEntity : ApplicationEntity
		where TModel : ApplicationModel
	{
		protected readonly IDatabaseService Db;
		protected readonly IConfigurationProvider MapperConfiguration;

		public GetListQuery(IDatabaseService db, IConfigurationProvider mapperConfiguration)
		{
			Db = db;
			MapperConfiguration = mapperConfiguration;
		}

		public virtual IEnumerable<TModel> Execute()
		{
			return Db.GetDbSet<TEntity>()
				.ProjectTo<TModel>(MapperConfiguration);
		}
	}
}
