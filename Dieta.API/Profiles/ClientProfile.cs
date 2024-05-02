﻿using AutoMapper;
using Dieta.Core.Data;
using Dieta.Core.ViewObject.Client;

namespace Dieta.API.Profiles
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<UserVO, Client>()
                .ForMember(x => x.UserName, x => x.MapFrom(x => x.Username))
                .ReverseMap();
        }
    }
}
