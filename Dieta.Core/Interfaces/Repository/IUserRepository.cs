using Dieta.Core.Entities;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Dieta.Core.Interfaces.Repository
{
    public interface IUserRepository
    {
        public Task<Result> CreateUser(ApplicationUser client);

        public Task<Result> SignInUser(ApplicationUser user, string password);
        public Task<ApplicationUser> FindById(string id);
        public Task<ApplicationUser> FindByEmail(string email);
        public Task<List<ApplicationUser>> FindAll();
       
    }
}
