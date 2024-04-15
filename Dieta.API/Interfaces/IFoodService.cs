﻿using Dieta.Core.Data;
using Dieta.Core.ViewObject;
using FluentResults;

namespace Dieta.API.Interfaces
{
    public interface IFoodService
    {
        public Task<Result> AddFoodAsync(FoodVO food, double amount, int meal);
    }
}
