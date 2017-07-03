namespace Domain.Base
{
	public interface IApplicationEntity
	{
		int Id { get; set; }
		bool Activo { get; set; }
	}
}