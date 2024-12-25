using Domain.Common;
using Domain.Enums;
using Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Base;

public abstract class Party(
    Guid id,
    Name name,
    SexEnum sex) : Base( id, DateTime.Now, null )
{
    public Name Name { get; set; } = name;
    public SexEnum Sex { get; set; } = sex;
}
