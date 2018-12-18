using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VMT.Models.Authentications;

namespace VMT.Repository.Authentications
{
    public interface IAuthRepository
    {
        Task<object> Register(RegisterModel user);
        Task<object> Login(LoginModel user);
        Task<object> Update(RegisterModel user);
    }
}
