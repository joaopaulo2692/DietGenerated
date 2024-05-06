using Dieta.Core.Data;
using Dieta.Core.Interfaces.Repository;
using Dieta.Core.ViewObject;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Dieta.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DietaController : ControllerBase
    {
        private readonly IFoodRepository _foodRepo;


        public DietaController(IFoodRepository alimentoRepo)
        {
            _foodRepo = alimentoRepo;
        }

        [HttpPost]
        [Route("Save")]
        public async Task<IActionResult> SaveDiet([FromQuery]FoodVO alimentoVO)
        {
            try
            {
                Claim idUser = User.FindFirst(ClaimTypes.NameIdentifier);

                await _foodRepo.CreateAsync(alimentoVO);

                return StatusCode(StatusCodes.Status200OK, alimentoVO);
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
                await _foodRepo.CreateAsync(alimentoVO);

                return StatusCode(StatusCodes.Status200OK, alimentoVO);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetlAllAlimentos()
        {
            try
            {
                List<Food> alimentos = await _foodRepo.GetAllAsync();

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
    }
}
