using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VMT.Models.Authentications;

namespace VMT.Repository.Authentications
{
    public interface IAuthRepository
    {
        Task<string> Register(RegisterModel user);
        Task<string> Update(RegisterModel user);

    }
}
