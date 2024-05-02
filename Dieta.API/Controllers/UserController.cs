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
    }
}
