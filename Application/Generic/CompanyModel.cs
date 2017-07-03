namespace Application.Generic
{
	public class CompanyModel : ApplicationModel
	{
		public int EmpresaId { get; set; }

		public override bool Equals(object obj)
		{
			var entity = obj as CompanyModel;
			return entity != null && base.Equals(entity) && EmpresaId == entity.EmpresaId;
		}

		protected bool Equals(CompanyModel other)
		{
			return base.Equals(other) && EmpresaId == other.EmpresaId;
		}

		public override int GetHashCode()
		{
			return base.GetHashCode() * EmpresaId.GetHashCode();
		}
	}
}
