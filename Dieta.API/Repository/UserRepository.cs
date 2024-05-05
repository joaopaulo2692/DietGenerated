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
        private readonly SignInManager<Client> _signInManager;
        private readonly DietasDbContext _db;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserRepository(SignInManager<Client> signInManager, DietasDbContext db, IHttpContextAccessor httpContextAccessor)
        {
            _signInManager = signInManager;
            _db = db;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Result> CreateUser(Client user)
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

        public async Task<List<Client>> FindAll()
        {
            List<Client> clients = await _db.Clientes.ToListAsync();
            return clients;
        }

        public async Task<Client> FindByName(string userName)
        {
            try
            {
                Client clientDb = await _db.Clientes.Where(x => x.UserName == userName).FirstOrDefaultAsync();

                return clientDb;
            }
            catch(Exception ex)
            {
                return new Client();
            }
        }

        public Task<string> GetBearerTokenAsync()
        {
            return Task.FromResult(_httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", ""));
            
            
        }

        public async Task<Result> SignInUser(Client user, string password)
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
