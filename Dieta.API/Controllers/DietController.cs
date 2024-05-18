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

        [HttpPost]
        [Route("CreateDiet")]
        public async Task<IActionResult> CreateDiet([FromBody]DietSaveVO diet)
        {
            try
            {
                Claim idUser = User.FindFirst(ClaimTypes.NameIdentifier);
                if (idUser == null) return StatusCode(StatusCodes.Status401Unauthorized);

                Result newDiet = await _dietService.CreateDiet(diet,idUser.Value);
                if (newDiet.IsFailed)
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }
                return StatusCode(StatusCodes.Status200OK, newDiet);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

    }
}
