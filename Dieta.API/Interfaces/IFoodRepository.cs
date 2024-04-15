

using Dieta.Core.Data;
using Dieta.Core.ViewObject;
using FluentResults;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;

namespace Dieta.API.Interfaces
{
    public interface IFoodRepository
    {
        public Task<FoodVO> CreateAsync(FoodVO foodVO);
        public Task<List<Food>> GetAllAsync();
        public Task<IEnumerable<Food>> GetAll();
        public Task<IEnumerable<Food>> GetAllSavedAsync();
        public Food AmountConversion(Food food, double amount);
            
        public Task<Result> CreateListFoodAsync(List<Food> food);

        public Task<Result> AddFoodAsync(Food food, double amount, int meal);

    }
}
