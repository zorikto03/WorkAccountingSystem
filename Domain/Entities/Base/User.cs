using Domain.Common;
using Domain.ValueObjects;
using System.Xml.Linq;

namespace Domain.Entities.Base;

public class User
{
    public Guid Id { get; set; }
    public Name Name { get; set; }
    public int Sex { get; set; }

    private User() 
    {
    }

    public User( 
        Guid id, 
        Name name,
        LoginPassword loginPassword,
        int sex )
    {
        Id = id;
        Name = name;
        LoginPassword = loginPassword;
        Sex = sex;
    }

    public LoginPassword LoginPassword { get; private set; }

    public static Result<User> Create(string firstName, string lastName, string login, string password, int sex )
    {
        var nameResult = Name.Create( firstName, lastName );
        if ( nameResult.IsFailure )
            return Result.Failure<User>( nameResult.Error );

        var lpResult = LoginPassword.Create(login, password);
        if ( lpResult.IsFailure )
            return Result.Failure<User>( lpResult.Error );

        var user = new User( Guid.NewGuid(), nameResult.Value, lpResult.Value, sex );
        return user;
    }
}
