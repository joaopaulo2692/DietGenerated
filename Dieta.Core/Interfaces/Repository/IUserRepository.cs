using Dieta.Core.Data;
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
        public Task<Result> CreateUser(Client client);

        public Task<Result> SignInUser(Client user, string password);
        public Task<Client> FindByName(string id);
        public Task<List<Client>> FindAll();
        public Task<string> GetBearerTokenAsync();
    }
}
