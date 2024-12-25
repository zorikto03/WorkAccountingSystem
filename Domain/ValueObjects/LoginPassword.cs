using Domain.Common;
using Domain.ValueObjects.Base;

namespace Domain.ValueObjects;

public class LoginPassword : ValueObject
{
    private LoginPassword(string login, string password)
    {
        Login = login;
        Password = password;
    }

    public string Password { get; }
    public string Login { get; }

    public static Result<LoginPassword> Create(string login, string password)
    {
        // check valid values of login and pass

        var lp = new LoginPassword( login, password );
        return Result.Success( lp );
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        throw new NotImplementedException();
    }
}
