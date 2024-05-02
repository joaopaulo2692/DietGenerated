using Dieta.API.DietaContext;
using Dieta.Core.Data;
using Dieta.Core.Interfaces.Repository;
using FluentResults;
using Microsoft.AspNetCore.Identity;

namespace Dieta.API.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly SignInManager<Client> _signInManager;
        private readonly DietasDbContext _db;
public UserRepository(SignInManager<Client> signInManager, DietasDbContext db)
        {
            _signInManager = signInManager;
            _db = db;
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
    }
}
