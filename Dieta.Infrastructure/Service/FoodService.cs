using Dieta.Core.Data;
using Dieta.Core.Interfaces.Repository;
using Dieta.Core.Interfaces.Service;
using Dieta.Core.ViewObject;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dieta.Infrastructure.Service
{
    public class FoodService : IFoodService
    {
        private readonly IDietRepository _dietRepo;
        private readonly IUserRepository _userRepo;

        public FoodService(IDietRepository dietRepo, IUserRepository userRepo)
        {
            _dietRepo = dietRepo;
            _userRepo = userRepo;
        }

        public async Task<Result> AddFoodAsync(Food food, double amount, int meal, string idUser)
        {
            try
            {
                Diet dietDb = await _dietRepo.FindByUserIdAsync(idUser);
                if (dietDb == null)
                {
                    ApplicationUser user = await _userRepo.FindById(idUser);
                    Result dietResponse = await _dietRepo.CreateAsync(user, new Diet());
                    Result.Fail("Usuário sem dieta iniciada");
                }
                Food foodConvert = AmountConversion(food, amount);

                return Result.Fail("Usuário sem dieta iniciada");

            }
            catch(Exception ex)
            {
                return Result.Fail("Usuário sem dieta iniciada");
            }
        }

        public Food AmountConversion(Food food, double amount)
        {
            if (amount == 100)
            {
                return food;
            }
            else
            {
                Food foodConverted = new Food()
                {
                    FoodName = food.FoodName,
                    Prepare = food.Prepare,
                    //Amount = amount,
                    Protein = (food.Protein * amount) / 100,
                    Carb = (food.Carb * amount) / 100,
                    Fat = (food.Fat * amount) / 100,
                    Fiber = (food.Fiber * amount) / 100,
                    Kcal = (food.Kcal * amount) / 100
                };
                return foodConverted;
            }
        }
    }
}
