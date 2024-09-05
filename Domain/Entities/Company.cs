using Domain.Entities.Base;
using Domain.ValueObjects;

namespace Domain.Entities;

public class Company : Base.Base
{
    public IEnumerable<User> Users { get; set; } = Enumerable.Empty<User>();
    public CompanyName CompanyName { get; private set; }


    public Company( 
        Guid id, 
        CompanyName companyName 
        ) : base( id, DateTime.Now, null ) =>
            CompanyName = companyName;
}
