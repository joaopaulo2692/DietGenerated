using Dieta.Core.Data;
using Dieta.Core.Interfaces.Repository;
using Dieta.Infrastructure.DietaContext;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Dieta.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _db;

        public UserRepository(SignInManager<ApplicationUser> signInManager, ApplicationDbContext db)
        {
            _signInManager = signInManager;
            _db = db;
        }

        public async Task<Result> CreateUser(ApplicationUser user)
        {
            try
            {
                user.Id = Guid.NewGuid().ToString();
                user.CreatedAt = DateTime.Now;
                user.UpdatedAt = DateTime.Now;
                user.NormalizedUserName = user.Email.ToUpper();
                user.NormalizedEmail = user.Email.ToUpper();
                

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

        public async Task<ApplicationUser> FindByEmail(string email)
        {
            try
            {
                ApplicationUser? user = await _signInManager
                                               .UserManager
                                               .Users
                                               .Where(x => x.DisabledAt == null &&
                                                           x.Email == email)
                                               .FirstOrDefaultAsync();


                return user;

            }
            catch (Exception ex)
            {
                return new ApplicationUser();
            }
        }

        public async Task<ApplicationUser> FindById(string id)
        {
            try
            {
                ApplicationUser? user = await _signInManager
                                               .UserManager
                                               .Users
                                               .Where(x => x.DisabledAt == null &&
                                                           x.Id == id)
                                               .FirstOrDefaultAsync();


                return user;
            
            }
            catch(Exception ex)
            {
                return new ApplicationUser();
            }
        }

        public Task<string> GetBearerTokenAsync()
        {
            throw new NotImplementedException();
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
