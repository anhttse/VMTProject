using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using VMT.Identity;

namespace VMT.Repository.Authorizations
{
    public class SecurityService : ISecurityService
    {
        private readonly ApplicationIdentityDbContext _context;

        public SecurityService(ApplicationIdentityDbContext context)
        {
            _context = context;
        }
        public Task<bool> AuthorizeAsync(ClaimsPrincipal user, string groupName, string perAction)
        {
            if (!user.Identity.IsAuthenticated) return Task.FromResult(false);

            return Task.FromResult(true);
        }
    }
}
