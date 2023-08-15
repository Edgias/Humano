using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Edgias.Humano.Infrastructure.Identity
{
    public class IdentitySeed
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, 
            RoleManager<IdentityRole> roleManager)
        {
            IdentityRole? role = await roleManager.FindByNameAsync(IdentityConstants.ADMINISTRATORS);

            if (role is null)
            {
                await roleManager.CreateAsync(new IdentityRole(IdentityConstants.ADMINISTRATORS));

                role = await roleManager.FindByNameAsync(IdentityConstants.ADMINISTRATORS);

                string[] permissions = Enum.GetNames(typeof(Permissions));

                foreach (string permission in permissions)
                {
                    Claim claim = new(ClaimTypes.Role, permission);
                    await roleManager.AddClaimAsync(role!, claim);
                }
            }

            string userName = "demo@humano.co.zw";

            ApplicationUser? user = await userManager.FindByNameAsync(userName);

            if (user is null)
            {
                // Set up default user info.
                ApplicationUser? defaultUser = new()
                {
                    FirstName = "Demo",
                    LastName = "Demo",
                    UserName = userName,
                    Email = userName,
                    CreatedBy = userName,
                    LastModifiedBy = userName
                };

                // Create default user
                var result = await userManager.CreateAsync(defaultUser, IdentityConstants.DEFAULT_PASSWORD);

                // Check if user has been created and add to the admin role
                defaultUser = await userManager.FindByNameAsync(defaultUser.UserName);
                await userManager.AddToRoleAsync(defaultUser, IdentityConstants.ADMINISTRATORS);

                // Get role claims and add them to user.
                IList<Claim> roleClaims = await roleManager.GetClaimsAsync(role!);
                await userManager.AddClaimsAsync(defaultUser, roleClaims);
            }
        }
    }
}
