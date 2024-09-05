namespace Domain.Entities.Base;

public class Memo : Base
{
    public string Title { get; private set; }
    
    public Memo( Guid id, string title) : base( id, DateTime.Now, DateTime.Now ) =>
        Title = title;

}
