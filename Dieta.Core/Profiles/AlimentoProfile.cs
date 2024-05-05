using AutoMapper;
using Dieta.Core.Data;
using Dieta.Core.ViewObject;


namespace Dieta.API.Profiles
{
    public class AlimentoProfile : Profile
    {
        public AlimentoProfile()
        {
            CreateMap<Food, FoodVO>()
                .ReverseMap();
        }
    }
}
