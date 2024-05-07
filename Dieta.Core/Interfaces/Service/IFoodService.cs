using Dieta.Core.Data;
using Dieta.Core.ViewObject;
using FluentResults;

namespace Dieta.Core.Interfaces.Service
{
    public interface IFoodService
    {
        public Task<Result> AddFoodAsync(Food food, double amount, int meal, string idUser);

        public Food AmountConversion(Food food, double amount);
    }
}
