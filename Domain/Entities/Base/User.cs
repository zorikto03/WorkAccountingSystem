using Domain.Common;
using Domain.Enums;
using Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Base;

public class User : Party
{
    private User(
        Guid id,
        SexEnum sexEnum,
        Name name,
        LoginPassword loginPassword) : base(id, name, sexEnum)
    {
        LoginPassword = loginPassword;
    }

    public LoginPassword LoginPassword { get; private set; }

    public static Result<User> Create(string firstName, string lastName, string login, string password, SexEnum sexEnum )
    {
        var nameResult = Name.Create( firstName, lastName );
        if ( nameResult.IsFailure )
            return Result.Failure<User>( nameResult.Error );

        var lpResult = LoginPassword.Create(login, password);
        if ( lpResult.IsFailure )
            return Result.Failure<User>( lpResult.Error );

        var user = new User( Guid.NewGuid(), sexEnum, nameResult.Value, lpResult.Value );
        return user;
    }
}
