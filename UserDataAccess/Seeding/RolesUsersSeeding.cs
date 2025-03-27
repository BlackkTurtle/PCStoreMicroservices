using Microsoft.AspNetCore.Identity;
using UserDataAccess.Models;

namespace UserDataAccess.Seeding
{
    public class RolesUsersSeeding
    {
        public static async Task SeedRolesAsync(RoleManager<ApplicationRole> roleManager)
        {
            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                await roleManager.CreateAsync(
                    new ApplicationRole { Id = Guid.NewGuid(), Name = "Administrator", NormalizedName = "ADMINISTRATOR".ToUpper() });
            }

            if (!await roleManager.RoleExistsAsync("User"))
            {
                await roleManager.CreateAsync(
                    new ApplicationRole { Id = Guid.NewGuid(), Name = "User", NormalizedName = "USER".ToUpper() });
            }
        }

        public static async Task SeedUsersAsync(UserManager<ApplicationUser> userManager)
        {
            // Seed Admin User
            var adminUser = new ApplicationUser
            {
                Id = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                UserName = "adminUser@example.com",
                Email = "adminUser@example.com",
                NormalizedUserName = "ADMINUSER",
                FirstName = "erfgeffe",
                LastName = "grgrf",
                Father = "gefgfgef"
            };

            if (userManager.Users.All(u => u.UserName != adminUser.UserName))
            {
                var result = await userManager.CreateAsync(adminUser, "Admin123!");
                if (result.Succeeded)
                {
                    // Assign the "Admin" role to the admin user
                    await userManager.AddToRoleAsync(adminUser, "Administrator");
                }
            }

            // Seed Standard User
            var standardUser = new ApplicationUser
            {
                Id = Guid.Parse("9c445865-a24d-4233-a6c6-9443d048cdb9"),
                UserName = "user@example.com",
                Email = "user@example.com",
                NormalizedUserName = "USER",
                FirstName="erfgeffe",
                LastName="grgrf",
                Father="gefgfgef"
            };

            if (userManager.Users.All(u => u.UserName != standardUser.UserName))
            {
                var result = await userManager.CreateAsync(standardUser, "User123!");
                if (result.Succeeded)
                {
                    // Assign the "User" role to the standard user
                    await userManager.AddToRoleAsync(standardUser, "User");
                }
            }
        }
    }
}
