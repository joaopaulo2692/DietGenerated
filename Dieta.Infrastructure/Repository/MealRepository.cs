using Dieta.Core.Entities;
using Dieta.Core.Interfaces.Repository;
using Dieta.Infrastructure.DietaContext;
using FluentResults;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dieta.Infrastructure.Repository
{
    public class MealRepository : IMealRepository
    {
        private readonly ApplicationDbContext _db;

        public MealRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Result> CreateInitialMeals(int idDiet)
        {
            try
            {
                Diet dietDb = await _db.Diets.Where(x => x.DietId == idDiet).FirstOrDefaultAsync();
                for (int i = 0;i< 7; i++)
                {
                    Meal meal = new Meal();
                    dietDb.Meals.Add(meal);
                }
                _db.SaveChangesAsync();
                return Result.Ok();
            }
            catch(Exception ex)
            {
                return Result.Fail("Erro ao adicionar refeiçoes na dieta");
            }
        }

        public async Task<Meal> FindById(int mealOrdenation, string userId)
        {
            try
            {
                Meal mealDb = await _db.Meals.Where(x => x.Ordenation == mealOrdenation &&
                                        x.Diets.Any(d => d.Client.Any(c => c.Id == userId))).FirstOrDefaultAsync();
                return mealDb;
            }
            catch(Exception ex)
            {
                return new Meal();
            }
        }
    }
}
