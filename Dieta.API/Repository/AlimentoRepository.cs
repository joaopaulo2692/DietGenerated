using AutoMapper;
using Dieta.API.DietaContext;
using Dieta.API.Interfaces;
using Dieta.Core.Data;
using Dieta.Core.ViewObject;
using FluentResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Collections.Generic;



namespace Dieta.API.Repository
{
    public class AlimentoRepository : IFoodRepository
    {
        private readonly DietasDbContext _db;
        private readonly IMapper _mapper;
        private readonly HttpClient _httpClient;

        public AlimentoRepository(DietasDbContext db, IMapper mapper, HttpClient httpClient)
        {
            _db = db;
            _mapper = mapper;
            _httpClient = httpClient;
        }

        public async Task<Result> AddFoodAsync(Food food, double amount, int ordenation)
        { 
            try{
                Meal meal = await _db.Refeicoes.Where(x => x.RefeicaoId == ordenation).FirstOrDefaultAsync();
                {
                    if(meal == null)
                    {
                        Meal mealCreated = new Meal()
                        {
                            Ordenation = ordenation
                        };
                    }
                }

                meal.Ordenation = ordenation;
                FoodsMeal alimentoRef = new FoodsMeal()
                {
                    Alimento = food,
                    Refeicao = meal,
                    Ordenation = 1
                };
                meal.AlimentosRefeicoes.Add(alimentoRef);
                Diet? diet = await _db.Dietas.FirstOrDefaultAsync();
                diet.Meals.Add(meal);
                Client? client = await _db.Clientes.FirstOrDefaultAsync();
                client.Dieta.Add(diet);
                


                await _db.SaveChangesAsync();
                
                return Result.Ok();
            }
                catch(Exception ex)
            {
                return Result.Fail("erro");
            }
            
        }

        public Food AmountConversion(Food food, double amount)
        {
            if(amount == 100)
            {
                return food;
            }
            else
            {
                Food foodConverted = new Food()
                {
                    FoodName = food.FoodName,
                    Prepare = food.Prepare,
                    Amount = amount,
                    Protein = (food.Protein * amount) / 100,
                    Carb = (food.Carb * amount) / 100,
                    Fat = (food.Fat * amount) / 100,
                    Fiber = (food.Fiber * amount) / 100,
                    Kcal = (food.Kcal * amount) / 100
                };
                return foodConverted;
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

        public async Task<Result> CreateListFoodAsync(List<Food> alimentos)
        {
            try
            {
                Result result = new Result();
                _db.Alimentos.AddRange(alimentos);
                await _db.SaveChangesAsync();
                return Result.Ok();
            }
            catch(Exception ex)
            {
                return Result.Fail("erro");
            }
        }

        public async Task<IEnumerable<Food>> GetAll()
        {
            var alunos = await _httpClient.GetFromJsonAsync<IEnumerable<Food>>("Dieta/GetAll");
            return alunos;
        }

        public async Task<List<Food>> GetAllAsync()
        {
            try
            {
                List<Food> alimentos = await _db.Alimentos.ToListAsync();

                return alimentos;
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
