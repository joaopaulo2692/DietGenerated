﻿using Dieta.Communication.ViewObject.Food;
using Dieta.Core.Entities;
using FluentResults;

namespace Dieta.Core.Interfaces.Service
{
    public interface IFoodService
    {
        public Task<Result> AddFoodAsync(FoodVO food, string idUser);
        public Task<Result> RemoveFoodAsync(FoodVO food, string idUser);

        public FoodVO AmountConversion(FoodVO food);

        public Task<IEnumerable<FoodVO>> GetAllAsync();
    }
}
