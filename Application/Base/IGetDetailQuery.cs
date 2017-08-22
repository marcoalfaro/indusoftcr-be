namespace Application.Base
{
	public interface IGetDetailQuery<TEntity, out TModel>
	{
		TModel Execute(int id);
	}
}