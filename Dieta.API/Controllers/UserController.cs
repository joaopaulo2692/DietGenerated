using AutoMapper;
using Dieta.Communication.ViewObject.Client;
using Dieta.Core.Entities;
using Dieta.Core.Interfaces.Repository;
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
                
                ApplicationUser client = await _userRepo.FindByEmail(user.Email);
                Result response = await _userRepo.SignInUser(client, user.Password);
              
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
        public async Task<IActionResult> GetById(string id)
        {
            ApplicationUser client = await _userRepo.FindById(id);
            return StatusCode(StatusCodes.Status200OK, client);
        }

        //[HttpPost]
        //[Route("DeleteUser")]
        //public async Task<IActionResult> DeleteUser()
        //{

        //}

      
    }
}
