using Dieta.Core.Data;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dieta.Core.Interfaces.Repository
{
    public interface IUserRepository
    {
        public Task<Result> CreateUser(Client client);

        public Task<Result> SignInUser(Client user, string password);
        public Task<Client> FindById(string id);
        public Task<List<Client>> FindAll();
    }
}
