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
                Client client = _mapper.Map<Client>(user);
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
                Client client = _mapper.Map<Client>(user);
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
            List<Client> clients= await _userRepo.FindAll();
            return StatusCode(StatusCodes.Status200OK, clients);
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(string id)
        {
            Client client = await _userRepo.FindById(id);
            return StatusCode(StatusCodes.Status200OK, client);
        }
    }
}
