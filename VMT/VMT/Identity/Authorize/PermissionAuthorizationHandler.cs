using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using VMT.Repository.Authorizations;


namespace VMT.Identity.Authorize
{
    public class PermissionAuthorizationHandler : AttributeAuthorizationHandler<PermissionAuthorizationRequirement, PermissionAttribute>
    {
        private readonly ISecurityService _authorizationService;

        public PermissionAuthorizationHandler(ISecurityService service)
        {
            _authorizationService = service;
        }
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionAuthorizationRequirement requirement, IEnumerable<PermissionAttribute> attributes)
        {
            foreach (var permissionAttribute in attributes)
            {
//                context.User.
                if (!await AuthorizeAsync(context.User, permissionAttribute.GroupName,permissionAttribute.GroupAction))
                {
                    return;
                }
            }

            context.Succeed(requirement);
        }

        private Task<bool> AuthorizeAsync(ClaimsPrincipal user, string groupName, string perAction)
        {
            return _authorizationService.AuthorizeAsync(user, groupName,perAction);
        }
    }
}
