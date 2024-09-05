namespace Domain.Common;

public class Error
{
    public static Error None = new( string.Empty, string.Empty );
    public static Error NullValue = new( "Error.NullValue", "Value cannot be null" );

    public string Code { get; init; }
    public string Message { get; init; }

    public Error(string code, string message)
    {
        Code = code;
        Message = message;
    }
}
