using AutoMapper;
using Dieta.Communication.ViewObject.Diet;
using Dieta.Core.Entities;
using Dieta.Core.Interfaces.Repository;
using Dieta.Core.Interfaces.Service;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dieta.Infrastructure.Service
{
    public class DietService : IDietService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepo;
        private readonly IDietRepository _dietRepo;
  
        public DietService(IMapper mapper, IUserRepository userRepo, IDietRepository dietRepo)
        {
            _mapper = mapper;
            _userRepo = userRepo;
            _dietRepo = dietRepo;
        }

        public async Task<Result> CreateDiet(DietSaveVO dietVO, string idUser)
        {
            try
            {
                ApplicationUser user = await _userRepo.FindById(idUser);
                Diet dietDb = await _dietRepo.FindByUserIdAsync(idUser);
                if (dietDb != null)
                {
                    Result dietDisable = await _dietRepo.DisableAsync(dietDb);
                    if (dietDisable.IsFailed)
                    {
                        return Result.Fail("Erro ao deletar dieta");
                    }
                }

                Diet newDiet = _mapper.Map<Diet>(dietVO);
                Result response = await _dietRepo.CreateAsync(user, newDiet);

                return response;

            }
            catch(Exception ex)
            {
                return Result.Fail("Erro ao criar nova dieta");
            }
        }

        public async Task<TotalDietVO> GetTotalDietAsync(string idUser)
        {
            try
            {
                ApplicationUser user = await _userRepo.FindById(idUser);
                if(user == null)
                {
                    return new TotalDietVO();
                }
                TotalDiet totalDietDb = await _dietRepo.FindTotalDietByUserIdAsync(idUser);
                if( totalDietDb == null)
                {
                    return new TotalDietVO();
                }

                TotalDietVO totalDietVO = _mapper.Map<TotalDietVO>(totalDietDb);
                return totalDietVO;
            }
            catch(Exception ex)
            {
                return new TotalDietVO();
            }
        }
    }
}
