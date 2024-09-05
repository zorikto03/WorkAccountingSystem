namespace Domain.Entities.Base;

public abstract class Base
{
    public Guid Id { get; private set; }
    public DateTime Created { get; private set; }
    public DateTime? Updated { get; private set; }

    public Base(Guid id, DateTime created, DateTime? updated)
    {
        Id = id;
        Created = created;
        Updated = updated;
    }
}
