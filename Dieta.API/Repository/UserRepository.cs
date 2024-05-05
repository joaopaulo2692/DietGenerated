using Dieta.API.DietaContext;
using Dieta.Core.Data;
using Dieta.Core.Interfaces.Repository;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Dieta.API.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _db;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserRepository(SignInManager<ApplicationUser> signInManager, ApplicationDbContext db, IHttpContextAccessor httpContextAccessor)
        {
            _signInManager = signInManager;
            _db = db;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Result> CreateUser(ApplicationUser user)
        {
            try
            {
                user.Id = Guid.NewGuid().ToString();
                IdentityResult resultCreateUser = await _signInManager
                                                            .UserManager
                                                            .CreateAsync(user, user.PasswordHash);
                if (!resultCreateUser.Succeeded)
                    return Result.Fail(resultCreateUser.Errors.FirstOrDefault().Description);

                return Result.Ok().WithSuccess(user.Id);
            }
            catch(Exception ex)
            {
                return Result.Fail("Erro ao inserir usuário");
            }
        }

        public async Task<List<ApplicationUser>> FindAll()
        {
            //List<ApplicationUser> clients = await _db.Clientes.ToListAsync();
            //return clients;
            return new List<ApplicationUser>();
        }

        public async Task<ApplicationUser> FindByName(string userName)
        {
            try
            {
                //ApplicationUser clientDb = await _db.Clientes.Where(x => x.UserName == userName).FirstOrDefaultAsync();

                //return clientDb;

                return new ApplicationUser();
            }
            catch(Exception ex)
            {
                return new ApplicationUser();
            }
        }

        public Task<string> GetBearerTokenAsync()
        {
            return Task.FromResult(_httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", ""));
            
            
        }

        public async Task<Result> SignInUser(ApplicationUser user, string password)
        {
            try
            {
                SignInResult result =
                    await _signInManager
                                .PasswordSignInAsync(
                                    user,
                                    password,
                                    false,
                                    false
                                );

                if (result.Succeeded)
                    return Result.Ok();
                else
                    return Result.Fail("Login attempt failed");
            }
            catch (Exception ex)
            {

                return Result.Fail("Erro ao logar");
            }
        }

     
    }
}
