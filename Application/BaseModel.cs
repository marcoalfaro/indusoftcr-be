using Domain.Base;

namespace Application
{
	public abstract class BaseModel<T> where T : BaseEntity, IEntity
	{
		public int Id { get; set; }
		public abstract void CopyFields(T entity);
		public abstract T ToEntity();
	}
}
