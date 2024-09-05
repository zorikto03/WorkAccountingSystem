using Domain.Common;
using Domain.Enums;
using Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Base;

public abstract class Party(
    Guid id,
    Name name,
    SexEnum sex,
    EmailAddressAttribute? email,
    PhoneAttribute? phone) : Base( id, DateTime.Now, null )
{
    public Name Name { get; private set; } = name;
    public SexEnum Sex { get; private set; } = sex;

    public EmailAddressAttribute? EmailAddress { get; set; } = email;
    public PhoneAttribute? Phone { get; set; } = phone;

    public Result SetPhone(PhoneAttribute phone)
    {
        if ( !phone.IsValid( phone ) )
            return Result.Failure( DomainError.Invalid( typeof( PhoneAttribute ).Name ) );

        Phone = phone;

        return Result.Success();
    }
}
