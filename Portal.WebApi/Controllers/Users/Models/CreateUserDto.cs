using Application.Features.Users.Commands;
using AutoMapper;
using Portal.WebApi.Common;

namespace Portal.WebApi.Controllers.Users.Models;

public class CreateUserDto : IMapWith<CreateUserCommand>
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Login { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public int SexId { get; set; }

    public static void Mapping(Profile profile) =>
        profile.CreateMap<CreateUserDto, CreateUserCommand>()
        .ForMember(x => x.FirstName, opt => opt.MapFrom(y => y.FirstName))
        .ForMember(x => x.LastName, opt => opt.MapFrom(y => y.LastName))
        .ForMember(x => x.Login, opt => opt.MapFrom(y => y.Login))
        .ForMember(x => x.Password, opt => opt.MapFrom(y => y.Password))
        .ForMember(x => x.SexId, opt => opt.MapFrom(y => y.SexId));
}

