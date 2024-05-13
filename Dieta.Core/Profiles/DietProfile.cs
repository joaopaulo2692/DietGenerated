using AutoMapper;
using Dieta.Communication.ViewObject.Diet;
using Dieta.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dieta.Core.Profiles
{
    public class DietProfile : Profile
    {
        public DietProfile()
        {
            CreateMap<TotalDiet, TotalDietVO>()
                .ReverseMap();

            CreateMap<DietSaveVO, Diet>()
                .ReverseMap();
        }
    }
}
