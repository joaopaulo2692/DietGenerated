using AutoMapper;
using Dieta.Communication.ViewObject.Food;
using Dieta.Core.Entities;
using Dieta.Core.Interfaces.Repository;
using Dieta.Core.Interfaces.Service;
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
        private readonly IFoodRepository _foodRepo;
        private readonly IMapper _mapper;
        private readonly IMealRepository _mealRepo;

        public FoodService(IDietRepository dietRepo, IUserRepository userRepo, IFoodRepository foodRepo, IMapper mapper, IMealRepository mealRepo)
        {
            _dietRepo = dietRepo;
            _userRepo = userRepo;
            _foodRepo = foodRepo;
            _mapper = mapper;
            _mealRepo = mealRepo;
        }

        public async Task<Result> AddFoodAsync(FoodVO food, string idUser)
        {
            try
            {
                Diet dietDb = await _dietRepo.FindByUserIdAsync(idUser);
                
                ApplicationUser user = await _userRepo.FindById(idUser);
                if (dietDb == null)
                {
                    Result dietResponse = await _dietRepo.CreateAsync(user, new Diet());
                    Result.Fail("Usuário sem dieta iniciada");
                }
                Food foodDb = await _foodRepo.FindByIdAsync(food.Id);

                FoodVO foodVO = _mapper.Map<FoodVO>(foodDb);
                foodVO.Amount = food.Amount;
                foodVO.Meal = food.Meal;
                foodVO.MealOrdenation = food.MealOrdenation;

                FoodVO foodConvert = AmountConversion(foodVO);
                Meal mealDb = await _mealRepo.FindById(food.MealOrdenation, idUser);
                if (mealDb == null) return Result.Fail("Refeição não encontrada");
                
                Food foodConverted = _mapper.Map<Food>(foodConvert);

                Result foodSaved = await _foodRepo.AddFoodAsync(foodConverted, dietDb, mealDb, food.MealOrdenation, food.Amount);
                if (foodSaved.IsFailed)
                {
                    return Result.Fail("Erro ao adicionar alimento");
                }
                TotalDiet totalDiet = dietDb.TotalDiet;
                totalDiet.Fiber += foodConvert.Fiber;
                totalDiet.Carb += foodConvert.Carb;
                totalDiet.Fat += foodConvert.Fat;
                totalDiet.Kcal+= foodConvert.Kcal;
                totalDiet.Protein += foodConvert.Protein;

                Result response = await _dietRepo.UpdateTotalDietByUserIdAsync(totalDiet, idUser);

                return response;

            }
            catch(Exception ex)
            {
                return Result.Fail("Usuário sem dieta iniciada");
            }
        }

        public FoodVO AmountConversion(FoodVO food)
        {
            if (food.Amount == 100)
            {
                return food;
            }
            else
            {
                FoodVO foodConverted = new FoodVO()
                {
                    Food = food.Food,
                    Protein = (food.Protein * food.Amount) / 100,
                    Carb = (food.Carb * food.Amount) / 100,
                    Fat = (food.Fat * food.Amount) / 100,
                    Fiber = (food.Fiber * food.Amount) / 100,
                    Kcal = (food.Kcal * food.Amount) / 100
                };
                return foodConverted;
            }
        }

        public async Task<List<FoodVO>> GetAllAsync()
        {
            try
            {
                List<Food> foodList = await _foodRepo.FindAllAsync();
                if(foodList == null)
                {
                    return new List<FoodVO>();
                }
                List<FoodVO> foodListVO = _mapper.Map<List<FoodVO>>(foodList);
                return foodListVO;
            }
            catch(Exception ex)
            {
                return new List<FoodVO>();
            }
        }

        public async Task<Result> RemoveFoodAsync(FoodVO food, string idUser)
        {
            try
            {
                Diet dietDb = await _dietRepo.FindByUserIdAsync(idUser);
              
                if (dietDb == null)
                {
                    Result.Fail("Usuário sem dieta iniciada");
                }
                ApplicationUser user = await _userRepo.FindById(idUser);
                Food foodDb = await _foodRepo.FindByIdAsync(food.Id);

                FoodVO foodVO = _mapper.Map<FoodVO>(foodDb);
                foodVO.Amount = food.Amount;
                foodVO.Meal = food.Meal;
                foodVO.MealOrdenation = food.MealOrdenation;

                FoodVO foodConvert = AmountConversion(foodVO);
                Meal mealDb = await _mealRepo.FindById(food.MealOrdenation, idUser);
                if (mealDb == null) return Result.Fail("Refeição não encontrada");

                Food foodConverted = _mapper.Map<Food>(foodConvert);

                FoodsMeal foodsMeal = new FoodsMeal()
                {
                    FoodsId = foodConvert.Id,
                    MealsId = mealDb.Id,
                    Ordenation = foodConvert.MealOrdenation,
                    Amount = foodConvert.Amount
                };

                Result foodSaved = await _foodRepo.RemoveFoodAsync(foodsMeal);
                if (foodSaved.IsFailed)
                {
                    return Result.Fail("Erro ao adicionar alimento");
                }
                TotalDiet totalDiet = dietDb.TotalDiet;
                totalDiet.Fiber -= foodConvert.Fiber;
                totalDiet.Carb -= foodConvert.Carb;
                totalDiet.Fat -= foodConvert.Fat;
                totalDiet.Kcal -= foodConvert.Kcal;
                totalDiet.Protein -= foodConvert.Protein;

                Result response = await _dietRepo.UpdateTotalDietByUserIdAsync(totalDiet, idUser);

                return response;

            }
            catch (Exception ex)
            {
                return Result.Fail("Usuário sem dieta iniciada");
            }
        }
    }
}
