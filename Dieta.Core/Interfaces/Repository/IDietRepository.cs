using Dieta.Core.Entities;
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
        public Task<Result> CreateAsync(ApplicationUser client, Diet diet);
        public Task<Diet> FindByUserIdAsync(string email);
    }
}
