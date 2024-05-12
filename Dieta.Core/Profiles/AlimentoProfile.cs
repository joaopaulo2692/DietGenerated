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

            CreateMap<FoodVO, Food>()
                .ReverseMap();

                //            .ForMember(x => x.Fiber, x => x.MapFrom(x => x.Fiber))
                //.ForMember(x => x.Protein, x => x.MapFrom(x => x.Protein))
                //.ForMember(x => x.Fat, x => x.MapFrom(x => x.Fat))
                //.ForMember(x => x.Carb, x => x.MapFrom(x => x.Carb))
                //.ForMember(x => x.Kcal, x => x.MapFrom(x => x.Kcal))
                //.ForMember(x => x.Am, x => x.MapFrom(x => x.Prepare))
        }
    }
}
