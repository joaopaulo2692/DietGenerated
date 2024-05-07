using Dieta.Core.Interfaces.Repository;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dieta.Infrastructure.Repository
{
    public class MealRepository : IMealRepository
    {
        public Task<Result> CreateInitialMeals(int idDiet)
        {
            throw new NotImplementedException();
        }
    }
}
