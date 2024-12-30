using Application.Features.Auth.Commands.Login;
using AutoMapper;
using Portal.WebApi.Common;

namespace Portal.WebApi.Controllers.Auth.Models;

public class LoginCommandDto : IMapWith<LoginCommand>
{
    public string Login { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

    public static void Mapping( Profile profile ) =>
        profile.CreateMap<LoginCommandDto, LoginCommand>()
        .ForMember( x => x.Login, opt => opt.MapFrom( y => y.Login ) )
        .ForMember( x => x.Password, opt => opt.MapFrom( y => y.Password ) );
        
}
