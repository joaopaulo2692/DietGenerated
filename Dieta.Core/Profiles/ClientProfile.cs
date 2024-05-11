using AutoMapper;
using Dieta.Communication.ViewObject.Client;
using Dieta.Core.Entities;


namespace Dieta.API.Profiles
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<UserVO, ApplicationUser>()
                .ForMember(x => x.UserName, x => x.MapFrom(x => x.Username))
                .ReverseMap();

            CreateMap<LoginVO, ApplicationUser>()
                .ReverseMap();
        }
    }
}
