using AspNetCoreMvcProject.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreMvcProject
{
    public class IdentityInitializer
    {
        public static void CreateAdmin(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            AppUser appUser = new AppUser
            {
                Name = "Omer",
                SurName = "Kalem",
                UserName = "OMERKA"
                
            };
            if (userManager.FindByNameAsync("Omer").Result == null)
            {
                var identityResult = userManager.CreateAsync(appUser,"1").Result;
            }
            if (roleManager.FindByNameAsync("Admin").Result == null)
            {
                IdentityRole identityRole = new IdentityRole
                { 
                    Name = "Admin"
                };
                var identityResult = roleManager.CreateAsync(identityRole).Result;
                var result = userManager.AddToRoleAsync(appUser, identityRole.Name).Result;
            }
        }
    }
}
