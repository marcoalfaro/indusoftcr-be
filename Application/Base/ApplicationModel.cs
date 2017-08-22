using Domain.Base;

namespace Application.Base
{
    public class ApplicationModel
    {
		public static readonly int defaultId = -1;
	    public int Id { get; set; }
	    public bool Activo { get; set; }
	    public virtual void UpdateEntityFields(ApplicationEntity entity)
	    {
		    entity.Activo = Activo;
	    }

		public override bool Equals(object obj)
	    {
		    var entity = obj as ApplicationModel;
		    return entity != null && Id == entity.Id && Activo == entity.Activo;
	    }

	    protected virtual bool Equals(ApplicationModel other)
	    {
		    return Id == other.Id && Activo == other.Activo;
	    }

	    public override int GetHashCode()
	    {
		    return Id.GetHashCode() * Activo.GetHashCode();
	    }
	}
}
