using Domain.Entities.Base;
using Domain.Enums;
using Riok.Mapperly.Abstractions;

namespace Portal.WebApi.Controllers.Models;

public class UserVm
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public SexEnum Sex { get; set; }
}

[Mapper(EnumMappingStrategy = EnumMappingStrategy.ByName)]
public static partial class UserVmMapper
{
    public static partial UserVm EntityToVm( User user );
}
