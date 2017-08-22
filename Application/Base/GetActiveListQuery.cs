using System.Collections.Generic;
using System.Linq;
using Application.Interfaces;
using AutoMapper;
using Domain.Base;

namespace Application.Base
{
	public class GetActiveListQuery<TEntity, TModel> : GetListQuery<TEntity, TModel>, IGetActiveListQuery<TEntity, TModel>
		where TEntity : ApplicationEntity
		where TModel : ApplicationModel
	{
		public GetActiveListQuery(IDatabaseService db, IConfigurationProvider mapperConfiguration) : base(db, mapperConfiguration)
		{
		}
		public override IEnumerable<TModel> Execute()
		{
			return base.Execute().Where(x => x.Activo);
		}
	}
}