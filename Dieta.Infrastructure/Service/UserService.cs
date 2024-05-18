using AutoMapper;
using Dieta.Communication.ViewObject.Client;
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
    public class UserService : IUserService
       
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepo;
        private readonly IDietRepository _dietRepo;
        private readonly IMealRepository _mealRepo;

        public UserService(IMapper mapper, IUserRepository userRepo, IDietRepository dietRepo, IMealRepository mealRepo)
        {
            _mapper = mapper;
            _userRepo = userRepo;
            _dietRepo = dietRepo;
            _mealRepo = mealRepo;
        }

        public async Task<Result> CreateUser(UserVO user)
        {
            try
            {
                ApplicationUser userDb = await _userRepo.FindByEmail(user.Email);
                if (userDb != null) 
                {
                    return Result.Fail("E-mail já cadastrado");
                }
                ApplicationUser client = _mapper.Map<ApplicationUser>(user);
                Result response = await _userRepo.CreateUser(client);
                if(response.IsFailed)
                {
                    return Result.Fail("Erro ao criar usuário");
                }
                string userId = response.Successes.FirstOrDefault().Message;
                ApplicationUser userSave = await _userRepo.FindById(userId);
                
                Diet diet = new Diet();
                diet.DietName = user.DietName;
                diet.DietType = user.DietType;
       
                Result dietGenerator = await _dietRepo.CreateAsync(userSave, diet);
                if(dietGenerator.IsFailed)
                {
                    return Result.Fail("Erro ao criar dieta");
                }

                return dietGenerator;
            }
            catch (Exception ex)
            {
                return Result.Fail("Erro ao criar usuário");
            }
        }

        public async Task<Result> Login(LoginVO user)
        {
            try
            {
                ApplicationUser client = await _userRepo.FindByEmail(user.Email);
                if (client == null) 
                {
                    return Result.Fail("Erro ao fazer Login");
                }
                Result response = await _userRepo.SignInUser(client, user.Password);

                return response;
            }
            catch(Exception ex)
            {
                return Result.Fail("Erro ao fazer Login");
            }
        }
    }
}
