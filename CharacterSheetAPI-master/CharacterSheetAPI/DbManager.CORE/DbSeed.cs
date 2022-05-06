using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DbManager.CORE
{
    public class DbSeed
    {
        private static IServiceProvider _serviceProvider;
        public static async Task InitializeAsync(DbCharacterContext context, IServiceProvider serviceProvider)
        {

            _serviceProvider = serviceProvider;
            await SeedAdminAsync(context);





        }

        private static async Task SeedAdminAsync(DbCharacterContext context)
        {
            var RoleManager = _serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            string[] roleNames = { "Admin", "Member", "Org" };
            IdentityResult roleResult;
            foreach (var roleName in roleNames)
            {
                var roleExist = await RoleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
                }

            }
            var UserManager = _serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            IdentityResult userResult;
            string[] mails = { "Admin@mail.com" };
            for (int i = 0; i < 1; i++)
            {
                var userExist = await UserManager.FindByNameAsync(mails[i]);
                if (userExist == null)
                {
                    var User = new IdentityUser(mails[i]);
                    User.Email = mails[i];

                    userResult = await UserManager.CreateAsync(User, "!QAZzaq1");
                    await UserManager.AddToRoleAsync(User, roleNames[i]);
                }
            }
        }

       
    }
}
