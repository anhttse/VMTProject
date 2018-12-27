using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using VMT.Identity;

namespace VMT.Repository.Authorizations
{
    public interface ISecurityService
    {
        Task<bool> AuthorizeAsync(ClaimsPrincipal user, string group,string groupAction);
    }
}
