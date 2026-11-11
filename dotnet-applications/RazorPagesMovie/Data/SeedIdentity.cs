
using Microsoft.AspNetCore.Identity;

namespace RazorPagesMovie.Data;

public static class SeedIdentity
{
    public static async Task InitializeAsync(IServiceProvider serviceProvider)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
        var configuration = serviceProvider.GetRequiredService<IConfiguration>();

        const string adminEmail = "admin@example.com";

        // Create the Admin role if it doesn't exist.
        if (!await roleManager.RoleExistsAsync("Admin"))
        {
            await roleManager.CreateAsync(new IdentityRole("Admin"));
        }

        // Get the initial admin password from User Secrets.
        var adminPassword = configuration["AdminUser:Password"];

        if (string.IsNullOrWhiteSpace(adminPassword))
        {
            throw new InvalidOperationException(
                "AdminUser:Password is not configured in User Secrets."
            );
        }

        // Find the existing admin user.
        var adminUser = await userManager.FindByNameAsync("admin")
            ?? await userManager.FindByEmailAsync(adminEmail);

        if (adminUser == null)
        {
            // Create the admin user.
            adminUser = new IdentityUser
            {
                UserName = adminEmail,
                Email = adminEmail,
                EmailConfirmed = true
            };

            var result = await userManager.CreateAsync(adminUser, adminPassword);

            if (!result.Succeeded)
            {
                var errors = string.Join(
                    ", ",
                    result.Errors.Select(error => error.Description)
                );

                throw new InvalidOperationException(
                    $"Failed to create admin user: {errors}"
                );
            }
        }
        else if (adminUser.UserName != adminEmail)
        {
            // Update the existing username to match the login email.
            var result = await userManager.SetUserNameAsync(
                adminUser,
                adminEmail
            );

            if (!result.Succeeded)
            {
                var errors = string.Join(
                    ", ",
                    result.Errors.Select(error => error.Description)
                );

                throw new InvalidOperationException(
                    $"Failed to update admin username: {errors}"
                );
            }
        }

        // Assign the Admin role if the user doesn't already have it.
        if (!await userManager.IsInRoleAsync(adminUser, "Admin"))
        {
            await userManager.AddToRoleAsync(adminUser, "Admin");
        }
    }
}
