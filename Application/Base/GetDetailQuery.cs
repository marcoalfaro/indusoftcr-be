using System.Linq;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Base;

namespace Application.Base
{
	public class GetDetailQuery<TEntity, TModel> : IGetDetailQuery<TEntity, TModel>
		where TEntity : ApplicationEntity
		where TModel : ApplicationModel
	{
		protected readonly IDatabaseService Db;
		protected readonly IConfigurationProvider MapperConfiguration;

		public GetDetailQuery(IDatabaseService db, IConfigurationProvider mapperConfiguration)
		{
			Db = db;
			MapperConfiguration = mapperConfiguration;
		}

		public virtual TModel Execute(int id)
		{
			return Db.GetDbSet<TEntity>()
				.Where(x => x.Id == id)
				.ProjectTo<TModel>(MapperConfiguration)
				.SingleOrDefault();
		}
	}
}