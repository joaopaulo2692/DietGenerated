﻿using Dieta.Core.Data;
using Dieta.Core.ViewObject;
using FluentResults;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;

namespace Dieta.Core.Interfaces.Repository
{
    public interface IFoodRepository
    {
        public Task<Result> CreateAsync(Food food, double amount, int meal);
        public Task<List<Food>> GetAllAsync();
        public Task<IEnumerable<Food>> GetAll();
        public Task<IEnumerable<Food>> GetAllSavedAsync();

        public Task<Result> CreateListFoodAsync(List<Food> food);

        public Task<Result> AddFoodAsync(Food food, Diet diet, Meal meal, int ordenationFood);

    }
}
