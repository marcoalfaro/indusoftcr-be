using System;
using System.Collections.Generic;
using System.Linq;
using Application.Interfaces;
using Domain.Base;

namespace Application
{
	public class GetListQuery<TEntity, TModel> : IGetListQuery<TEntity, TModel>
		where TEntity : BaseEntity
		where TModel : BaseModel<TEntity>
	{
		private readonly IDatabaseService db;

		public GetListQuery(IDatabaseService database)
		{
			db = database;
		}

		public IEnumerable<TModel> Execute()
		{
			return db.GetDbSet<TEntity>()
				.Select(x => Activator.CreateInstance(typeof(TModel), x) as TModel);
		}
	}
}
