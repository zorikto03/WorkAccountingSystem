namespace Domain.Entities.Base;

public abstract class Base
{
    public Guid Id { get; set; }
    public DateTime Created { get; set; }
    public DateTime? Updated { get; set; }

    public Base(Guid id, DateTime created, DateTime? updated)
    {
        Id = id;
        Created = created;
        Updated = updated;
    }
}
