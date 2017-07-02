namespace Application.Generic
{
	public interface IGetDetailQuery<TEntity, out TModel>
	{
		TModel Execute(int id);
	}
}