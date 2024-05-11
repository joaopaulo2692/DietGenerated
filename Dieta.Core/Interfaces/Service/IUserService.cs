using Dieta.Communication.ViewObject.Client;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dieta.Core.Interfaces.Service
{
    public interface IUserService
    {
        public Task<Result> CreateUser(UserVO userVO);
    }
}
