
using Dieta.API.Interfaces;
using Dieta.Core.Data;
using Dieta.Core.ViewObject;
using Microsoft.AspNetCore.Mvc;

namespace Dieta.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DietaController : ControllerBase
    {
        private readonly IFoodRepository _alimentoRepo;

        public DietaController(IFoodRepository alimentoRepo)
        {
            _alimentoRepo = alimentoRepo;
        }

        [HttpPost]
        [Route("Save")]
        public async Task<IActionResult> SaveDiet([FromQuery]FoodVO alimentoVO)
        {
            try
            {
                await _alimentoRepo.CreateAsync(alimentoVO);

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
                await _alimentoRepo.CreateAsync(alimentoVO);

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
                List<Food> alimentos = await _alimentoRepo.GetAllAsync();

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
                IEnumerable<Food> listaALimentos = await _alimentoRepo.GetAllSavedAsync();
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
