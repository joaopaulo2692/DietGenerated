using Dieta.Core.Data;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dieta.Core.Interfaces.Repository
{
    public interface IDietRepository
    {
        public Task<Result> CreateUser(ApplicationUser client);
    }
}
