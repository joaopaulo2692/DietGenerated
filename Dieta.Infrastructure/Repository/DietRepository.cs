using Dieta.Communication.ViewObject.Client;
using Dieta.Core.Entities;
using Dieta.Core.Interfaces.Repository;
using Dieta.Infrastructure.DietaContext;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Dieta.Infrastructure.Repository
{
    public class DietRepository : IDietRepository
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _db;

        public DietRepository(SignInManager<ApplicationUser> signInManager, ApplicationDbContext db)
        {
            _signInManager = signInManager;
            _db = db;
        }

        public async Task<Result> CreateAsync(ApplicationUser client, Diet diet)
        {
            try
            {
                ApplicationUser? userDb = await _signInManager.UserManager.FindByIdAsync(client.Id);
                diet.UpdatedAt = DateTime.Now;
                diet.CreatedAt = DateTime.Now;
                diet.Meals = new List<Meal>();
                for (int i = 0; i < 5; i++)
                {
                    Meal meal = new Meal();
                    meal.NameMeal = $"Refeição {i + 1}";
                    meal.Ordenation = i + 1;
                    diet.Meals.Add(meal);
                }
                TotalDiet newTotalDiet = new TotalDiet();
                diet.TotalDiet= newTotalDiet;
                diet.Client = new List<ApplicationUser>();
                diet.Client.Add(userDb);
                _db.Diets.Add(diet);

                await _db.SaveChangesAsync();

                diet.TotalDietId = newTotalDiet.Id;

                await _db.SaveChangesAsync();

                return Result.Ok().WithSuccess(diet.DietId.ToString());
            }

            catch(Exception ex)
            {
                return Result.Fail("Erro ao criar dieta");
            }
        }

        public async Task<TotalDiet> FindTotalDietByUserIdAsync(string id)
        {
            try
            {
                //TotalDiet totalDiet = await _db.TotalDiets.Where(x => x.Id == totalId).FirstOrDefaultAsync();
                TotalDiet totalDiet = await _db.TotalDiets
                                    .FirstOrDefaultAsync(x => x.Diet.Client.Any(c => c.Id == id));
                return totalDiet;
            }
            catch(Exception ex)
            {
                return new TotalDiet();
            }
        }

        public async Task<Diet> FindByUserIdAsync(string userId)
        {
            try
            {
                Diet dietDb = await _db.Diets.Where(x => x.DisabledAt == null)
                             .Include(x => x.TotalDiet)
                             .FirstOrDefaultAsync(x => x.Client.Any(c => c.Id == userId));


                return dietDb;
            }
            catch(Exception ex)
            {
                return new Diet();
            }
        }

        public async Task<Result> UpdateTotalDietByUserIdAsync(TotalDiet totalDiet, string id)
        {
            try
            {
                //TotalDiet totalDiet = await _db.TotalDiets.Where(x => x.Id == totalId).FirstOrDefaultAsync();
                TotalDiet totalDietDb = await _db.TotalDiets
                                    .FirstOrDefaultAsync(x => x.Diet.Client.Any(c => c.Id == id));
                totalDietDb = totalDiet;
                await _db.SaveChangesAsync();

                return Result.Ok();
            }
            catch (Exception ex)
            {
                return Result.Fail("Erro ao atualizar o total da dieta");
            }
        }

        public async Task<Result> DisableAsync(Diet diet)
        {
            try
            {
                Diet dietDb = await _db.Diets.Where(x => x.DietId == diet.DietId && x.DisabledAt == null).FirstOrDefaultAsync();
                dietDb.DisabledAt = DateTime.Now;
                dietDb.UpdatedAt = DateTime.Now;

                await _db.SaveChangesAsync();
                return Result.Ok();
            }
            catch(Exception ex)
            {
                return Result.Fail("Erro ao desabilitar dieta");
            }
        }
    }
}
