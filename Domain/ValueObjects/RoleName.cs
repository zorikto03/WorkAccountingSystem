using Domain.Common;
using Domain.ValueObjects.Base;

namespace Domain.ValueObjects;

public class RoleName : ValueObject
{
    public string Name { get; init; }
    public string Description { get; private set; }

    public static Result<RoleName> Create( string name, string description )
    {
        if ( string.IsNullOrEmpty( name ) )
            return Result.Failure<RoleName>( DomainError.IsEmpty( nameof( name ) ) );

        return new RoleName()
        {
            Name = name,
            Description = description
        };
    } 


    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Name; 
        yield return Description;
    }
}
