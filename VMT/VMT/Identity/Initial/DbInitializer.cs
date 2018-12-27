using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using VMT.Identity.Enum;

namespace VMT.Identity.Initial
{
    public class DbInitializer:IDbInitializer
    {
        private readonly IServiceProvider _serviceProvider;

        public DbInitializer(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public async void Initialize()
        {
            using (var serviceScope = _serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                //create database schema if none exists
                var context = serviceScope.ServiceProvider.GetService<ApplicationIdentityDbContext>();
                context.Database.EnsureCreated();

                //If there is already an Administrator role, abort
                var _roleManager = serviceScope.ServiceProvider.GetService<RoleManager<RoleGroup>>();
                if (!(await _roleManager.RoleExistsAsync("Administrator")))
                {
                    //Create the Administartor Role
                    await _roleManager.CreateAsync(new RoleGroup("Administrator"));
                }
                //Create the default Admin account and apply the Administrator role
                var _userManager = serviceScope.ServiceProvider.GetService<UserManager<User>>();
                string user = "admin";
                string password = "VMT@2018";
                var success = await _userManager.CreateAsync(new User { UserName = user, Email = user, EmailConfirmed = false }, password);
                if (success.Succeeded)
                {
                    await _userManager.AddToRoleAsync(await _userManager.FindByNameAsync(user), "Administrator");
                }

                //Create PermissionAction
                var permissionActions = System.Enum.GetValues(typeof(Common.PermissionAction)).Cast<Common.PermissionAction>();
                foreach (var action in permissionActions)
                {
                    if (!context.PermissionAction.Any(x => x.Name.Equals(action)))
                    {
                        await context.PermissionAction.AddAsync(new PermissionAction {Name = action.ToString()});
                    }
                }

               await context.SaveChangesAsync();
            }
        }
    }
}
