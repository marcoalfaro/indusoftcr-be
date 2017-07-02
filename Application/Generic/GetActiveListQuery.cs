using System.Collections.Generic;
using System.Linq;
using Application.Generic;
using Application.Interfaces;
using AutoMapper;
using Domain.Base;

namespace Application.Generic
{
	public class GetActiveListQuery<TEntity, TModel> : GetListQuery<TEntity, TModel>, IGetActiveListQuery<TEntity, TModel>
		where TEntity : BaseEntity
		where TModel : ActivableEntity
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