using System.Net.Http.Headers;

namespace Domain.Common;

public class Result
{
    public Result(bool isSuccess, Error error)
    {
        if ((isSuccess && error != Common.Error.None) 
            || (!isSuccess && error == Common.Error.None) )
        {
            throw new ArgumentException("Invalid params");
        }

        IsSuccess = isSuccess;
        Error = error;
    }

    public Error Error { get; }
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;

    public static Result Success() => new Result( true, Error.None );
    public static Result Failure( Error error ) => new Result( false, error );

    public static Result<TValue> Success<TValue>( TValue value ) => 
        new Result<TValue>( value, true, Error.None );

    public static Result<TValue> Failure<TValue>( Error error ) => 
        new Result<TValue>( default, false, error );

    public static Result<TValue> Create<TValue>( TValue value ) => 
        value is not null ? Success( value ) : Failure<TValue>( Error.NullValue );

}
