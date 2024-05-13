using Dieta.Communication.ViewObject.Food;
using Dieta.Core.Interfaces.Service;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Dieta.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FoodController : ControllerBase
    {
        private readonly IFoodService _foodService;

        public FoodController(IFoodService foodService)
        {
            _foodService = foodService;
        }

        [HttpPost]
        [Route("Save")]
        public async Task<IActionResult> AddFood([FromBody]FoodVO food)
        {
            try
            {
                Claim idUser = User.FindFirst(ClaimTypes.NameIdentifier);
                if (idUser == null)
                {
                    return StatusCode(StatusCodes.Status401Unauthorized);
                }
                Result response = await _foodService.AddFoodAsync(food, idUser.Value);
                if (response.IsFailed)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
                return StatusCode(StatusCodes.Status201Created);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        [Route("Remove")]
        public async Task<IActionResult> RemoveFood([FromBody] FoodVO food)
        {
            try
            {
                Claim idUser = User.FindFirst(ClaimTypes.NameIdentifier);
                if (idUser == null)
                {
                    return StatusCode(StatusCodes.Status401Unauthorized);
                }
                Result response = await _foodService.RemoveFoodAsync(food, idUser.Value);
                if (response.IsFailed)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
