using COMP2139_Assignment1.Models;
using Microsoft.AspNetCore.Identity;

namespace COMP2139_Assignment1.Data
{
    public class Seed
    {
        public static async Task SeedRolesAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole(Enum.Roles.SuperAdmin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Enum.Roles.Seller.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Enum.Roles.Traveler.ToString()));
        }

        public static async Task SuperSeedRoleAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var superUser = new ApplicationUser
            {
                UserName = "superAdmin",
                Email = "superadmin@travelo.com",
                FirstName = "Super",
                LastName = "Admin",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };

            if (userManager.Users.All(u => u.Id != superUser.Id))
            {
                var user = await userManager.FindByEmailAsync(superUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(superUser, "Admin-123");

                    await userManager.AddToRoleAsync(superUser, Enum.Roles.Traveler.ToString());
                    await userManager.AddToRoleAsync(superUser, Enum.Roles.Seller.ToString());
                    await userManager.AddToRoleAsync(superUser, Enum.Roles.SuperAdmin.ToString());

                }
            }
        }
    }
}
