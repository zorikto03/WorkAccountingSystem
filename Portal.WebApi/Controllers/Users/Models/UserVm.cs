using AutoMapper;
using Domain.Entities.Base;
using Portal.WebApi.Common;

namespace Portal.WebApi.Controllers.Users.Models;

public class UserVm : IMapWith<User>
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public int SexId { get; set; }

    public static void Mapping(Profile profile) =>
        profile.CreateMap<User, UserVm>()
        .ForMember(x => x.FirstName, opt => opt.MapFrom(y => y.Name.FirstName))
        .ForMember(x => x.LastName, opt => opt.MapFrom(y => y.Name.LastName))
        .ForMember(x => x.SexId, opt => opt.MapFrom(y => y.Sex));
}

