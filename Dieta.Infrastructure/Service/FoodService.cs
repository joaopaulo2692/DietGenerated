using Dieta.Core.Data;
using Dieta.Core.Interfaces.Repository;
using Dieta.Core.Interfaces.Service;
using Dieta.Core.ViewObject;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dieta.Infrastructure.Service
{
    public class FoodService : IFoodService
    {
        private readonly IDietRepository _dietRepo;

        public FoodService(IDietRepository dietRepo)
        {
            _dietRepo = dietRepo;
        }

        public async Task<Result> AddFoodAsync(FoodVO food, string idUser)
        {
            try
            {
                Diet dietDb = await _dietRepo.FindByUserIdAsync(idUser);
                if (dietDb == null)
                {
                    Result.Fail("Usuário sem dieta iniciada");
                }
                return Result.Fail("Usuário sem dieta iniciada");

            }
            catch(Exception ex)
            {
                return Result.Fail("Usuário sem dieta iniciada");
            }
        }
    }
}
