using Domain.Enums;
using Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Base;

public class User(
    Guid id,
    SexEnum sexEnum,
    Name name,
    EmailAddressAttribute? email,
    PhoneAttribute? phone) : Party( id, name, sexEnum, email, phone )
{
    public Guid? CompanyId { get; set; } = null;
    public Company? Company { get; set; } = null;
}
