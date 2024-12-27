using Application.Features.Users.Commands;
using Riok.Mapperly.Abstractions;

namespace Portal.WebApi.Controllers.Models;

public class CreateUserDto
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Login { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public int SexId { get; set; }
}

[Mapper(EnumMappingStrategy = EnumMappingStrategy.ByName)]
public static partial class CreateUserMapper
{
    public static partial CreateUserCommand DtoToCommand( CreateUserDto dto );
}
