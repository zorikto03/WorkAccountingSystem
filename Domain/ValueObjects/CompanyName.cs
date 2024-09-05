using Domain.Common;
using Domain.ValueObjects.Base;

namespace Domain.ValueObjects;

public class CompanyName : ValueObject
{
    public const int MaxCompanyNameLength = 32;
    public string Value { get; init; }

    private CompanyName(string value)
    {
        Value = value;
    }

    public static Result<CompanyName> Create(string value)
    {
        if ( value.Length > MaxCompanyNameLength )
            return Result.Failure<CompanyName>( DomainError.ValueObject.TooLong( nameof( CompanyName ) ) );

        if ( string.IsNullOrEmpty( value ) )
            return Result.Failure<CompanyName>(DomainError.ValueObject.IsEmpty( nameof( CompanyName ) ) );

        return new CompanyName( value );
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
