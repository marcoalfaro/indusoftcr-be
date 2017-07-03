namespace Domain.Base
{
	public class CompanyEntity : ApplicationEntity
	{
		public int EmpresaId { get; set; }

		public override bool Equals(object obj)
		{
			var entity = obj as CompanyEntity;
			return entity != null && base.Equals(entity) && EmpresaId == entity.EmpresaId;
		}

		protected bool Equals(CompanyEntity other)
		{
			return base.Equals(other) && EmpresaId == other.EmpresaId;
		}

		public override int GetHashCode()
		{
			return base.GetHashCode() * EmpresaId.GetHashCode();
		}
	}
}