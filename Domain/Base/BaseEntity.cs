namespace Domain.Base
{
    public class BaseEntity: IEntity
    {
	    public static readonly int defaultId = -1;
	    public int Id { get; set; }

	    public override bool Equals(object obj)
	    {
		    var entity = obj as IEntity;
		    return entity != null && Id == entity.Id;
	    }

	    protected virtual bool Equals(BaseEntity other)
	    {
		    return Id == other.Id;
	    }

	    public override int GetHashCode()
	    {
		    return Id.GetHashCode();
	    }
	}
}
