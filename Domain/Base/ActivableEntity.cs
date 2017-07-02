namespace Domain.Base
{
	public class ActivableEntity : BaseEntity
	{
		public bool Activo { get; set; }

		public override bool Equals(object obj)
		{
			var entity = obj as ActivableEntity;
			return entity != null && base.Equals(entity) && Activo == entity.Activo;
		}

		protected bool Equals(ActivableEntity other)
		{
			return base.Equals(other) && Activo == other.Activo;
		}

		public override int GetHashCode()
		{
			return base.GetHashCode() * Activo.GetHashCode();
		}
	}
}