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
                diet.Client.Add(userDb);
                _db.Diets.Add(diet);

                await _db.SaveChangesAsync();
                return Result.Ok().WithSuccess(diet.DietId.ToString());
            }

            catch(Exception ex)
            {
                return Result.Fail("Erro ao criar dieta");
            }
        }

        public async Task<Diet> FindByUserIdAsync(string userId)
        {
            try
            {
                Diet? dietDb = await _db.Diets.Where(x => x.Client.Select(x => x.Id).FirstOrDefault() == userId).FirstOrDefaultAsync();
                return dietDb;
            }
            catch(Exception ex)
            {
                return new Diet();
            }
        }
    }
}
