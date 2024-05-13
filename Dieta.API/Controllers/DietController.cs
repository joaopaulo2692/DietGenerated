using Dieta.Communication.ViewObject.Diet;
using Dieta.Communication.ViewObject.Food;
using Dieta.Core.Entities;
using Dieta.Core.Interfaces.Repository;
using Dieta.Core.Interfaces.Service;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Dieta.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DietController : ControllerBase
    {
        private readonly IFoodRepository _foodRepo;
        private readonly IFoodService _foodService;
        private readonly IDietService _dietService;


        public DietController(IFoodRepository alimentoRepo, IFoodService foodSerice, IDietService dietService)
        {
            _foodRepo = alimentoRepo;
            _foodService = foodSerice;
            _dietService = dietService;
        }

        [HttpPost]
        [Route("Save")]
        public async Task<IActionResult> SaveDiet([FromBody]FoodVO food)
        {
            try
            {
                Claim idUser = User.FindFirst(ClaimTypes.NameIdentifier);

                Result response = await _foodService.AddFoodAsync(food, idUser.Value);

                return StatusCode(StatusCodes.Status200OK, response);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpPost]
        [Route("SaveRefeicao")]
        public async Task<IActionResult> RefeicaoAdd([FromQuery] FoodVO alimentoVO)
        {
            try
            {
                //await _foodRepo.CreateAsync(alimentoVO);

                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAllFood()
        {
            try
            {
                List<FoodVO> alimentos = await _foodService.GetAllAsync();

                return StatusCode(StatusCodes.Status200OK, alimentos);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }
        [HttpGet]
        [Route("GetAllSaved")]
        public async Task<IActionResult> GetAllSaved()
        {
            try
            {
                IEnumerable<Food> listaALimentos = await _foodRepo.GetAllSavedAsync();
                return StatusCode(StatusCodes.Status200OK, listaALimentos);
            }
            catch(Exception ex)
            {
                IEnumerable<Food> listaALimentos = new List<Food>();
                return StatusCode(StatusCodes.Status400BadRequest, listaALimentos);
            }
        }

        [HttpGet]
        [Route("GetTotalDiet")]
        public async Task<IActionResult> GetTotalDiet()
        {
            try
            {
                Claim idUser = User.FindFirst(ClaimTypes.NameIdentifier);
                if (idUser == null) return StatusCode(StatusCodes.Status401Unauthorized);

                TotalDietVO totalDiet = await _dietService.GetTotalDietAsync(idUser.Value);
                if(totalDiet == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }
                return StatusCode(StatusCodes.Status200OK, totalDiet);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
