using AutoMapper;
using Azure;
using Dieta.API.DietaContext;
using Dieta.API.Repository;
using Dieta.Core.Data;
using Dieta.Core.Interfaces.Repository;
using Dieta.Core.ViewObject.Client;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace Dieta.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserRepository _userRepo;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }


        [HttpPost]
        [Route("Save")]
        public async Task<IActionResult> SaveUser([FromBody]UserVO user)
        {

            try
            {
                ApplicationUser client = _mapper.Map<ApplicationUser>(user);
                Result response = await _userRepo.CreateUser(client);
                return StatusCode(StatusCodes.Status201Created, response);

            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginVO user)
        {
            try
            {
                
                ApplicationUser client = await _userRepo.FindByName(user.UserName);
                Result response = await _userRepo.SignInUser(client, user.Password);
                var bearer = await _userRepo.GetBearerTokenAsync();
                if(response.IsFailed)
                {
                    return StatusCode(StatusCodes.Status404NotFound, response);
                }

                return StatusCode(StatusCodes.Status200OK, response);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            List<ApplicationUser> clients= await _userRepo.FindAll();
            return StatusCode(StatusCodes.Status200OK, clients);
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(string userName)
        {
            ApplicationUser client = await _userRepo.FindByName(userName);
            return StatusCode(StatusCodes.Status200OK, client);
        }

        //[HttpPost]
        //[Route("DeleteUser")]
        //public async Task<IActionResult> DeleteUser()
        //{

        //}

      
    }
}
