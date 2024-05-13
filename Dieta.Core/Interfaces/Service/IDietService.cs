using Dieta.Communication.ViewObject.Client;
using Dieta.Communication.ViewObject.Diet;
using Dieta.Core.Entities;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dieta.Core.Interfaces.Service
{
    public interface IDietService
    {
        public Task<TotalDietVO> GetTotalDietAsync(string idUser);

        public Task<Result> CreateDiet(DietSaveVO user, string idUser);
    }
}
