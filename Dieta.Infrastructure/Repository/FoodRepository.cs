using AutoMapper;
using Dieta.Communication.ViewObject.Food;
using Dieta.Core.Entities;
using Dieta.Core.Interfaces.Repository;
using Dieta.Infrastructure.DietaContext;
using FluentResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Collections.Generic;



namespace Dieta.Infrastructure.Repository
{
    public class FoodRepository : IFoodRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly HttpClient _httpClient;

        public FoodRepository(ApplicationDbContext db, IMapper mapper, HttpClient httpClient)
        {
            _db = db;
            _mapper = mapper;
            _httpClient = httpClient;
        }

        public async Task<Result> AddFoodAsync(Food food,Diet diet, Meal meal, int ordenationFood, double amount)
        { 
            try{
                Diet dietDb = await _db.Diets.Where(x => x.DietId == diet.DietId).FirstOrDefaultAsync();
                if (dietDb == null) return Result.Fail("Dieta não encontrada");

                Meal mealDb = await _db.Meals.Where(x => x.Id == meal.Id).FirstOrDefaultAsync();
                if (mealDb == null) return Result.Fail("Refeição não encontrada");

                FoodsMeal foodsMeal = new FoodsMeal()
                {
                    FoodsId = food.Id,
                    MealsId = meal.Id,
                    Ordenation = ordenationFood,
                    Amount = amount
                };

                _db.FoodsMeal.Add(foodsMeal);
                //if(mealDb == null)
                //{
                //    mealDb = new List<FoodsMeal>();
                //}
                //mealDb.FoodsMeals.Add(foodsMeal);

                await _db.SaveChangesAsync();
                
                return Result.Ok();
            }
                catch(Exception ex)
            {
                return Result.Fail("erro");
            }
            
        }



        public async Task<FoodVO> CreateAsync(FoodVO alimentoVO)
        {
            try
            {
                Food alimento = _mapper.Map<Food>(alimentoVO);


                //_db.Alimentos.Add(alimento);
                await _db.SaveChangesAsync();
                return alimentoVO;
            }
            catch(Exception ex)
            {
                return alimentoVO;
            }

        }

        public Task<Result> CreateAsync(Food food, double amount, int meal)
        {
            throw new NotImplementedException();
        }

        public async Task<Result> CreateListFoodAsync(List<Food> alimentos)
        {
            try
            {
                Result result = new Result();
                //_db.Foods.AddRange(alimentos);
                await _db.SaveChangesAsync();
                return Result.Ok();
            }
            catch(Exception ex)
            {
                return Result.Fail("erro");
            }
        }

        public Task<IEnumerable<Food>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Food>> FindAllAsync()
        {
            try
            {
                List<Food> alimentos = await _db.Foods.ToListAsync();

                return new List<Food>();
            }
            catch (Exception ex)
            {
                return new List<Food>();
            }

        }

        public async Task<IEnumerable<Food>> GetAllSavedAsync()
        {
            try
            {
                //List<Alimentos> alimentos = await _db.Dietas
                //         .Where(d => d.Cliente.Any(c => c.ClienteId == 1)) // Filtra as dietas associadas ao cliente específico
                //         .SelectMany(d => d.Refeicoes)// Une todas as refeições das dietas encontradas
                ///.SelectMany(r => r.Alimentos) // Une todos os alimentos das refeições encontradas
                ///.ToListAsync();
                ///
                return new List<Food>();
                //return alimentos;
            }
            catch(Exception ex)
            {
                return new List<Food>();
            }
        }
    }
}
