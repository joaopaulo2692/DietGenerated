using Dieta.Core.Data;
using Dieta.Core.ViewObject;
using FluentResults;

namespace Dieta.Core.Interfaces.Service
{
    public interface IFoodService
    {
        public Task<Result> AddFoodAsync(FoodVO food, string idUser);
    }
}
