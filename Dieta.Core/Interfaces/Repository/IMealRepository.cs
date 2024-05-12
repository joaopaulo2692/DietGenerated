using Dieta.Core.Entities;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dieta.Core.Interfaces.Repository
{
    public interface IMealRepository
    {
        public Task<Result> CreateInitialMeals(int idDiet);
        public Task<Meal> FindById(int mealId, string userId);
    }
}
