using AutoMapper;
using Dieta.Communication.ViewObject.Food;
using Dieta.Core.Entities;




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
