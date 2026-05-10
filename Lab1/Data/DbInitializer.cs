using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Lab1.Data;

public class DbInitializer()
{
    //public static void Seed(WebApplication app)
    //{
    //    using var scope = app.Services.CreateScope();
    //    using var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();


    //}

    public static async Task SetupIdentityAdmin(WebApplication application)
    {
        using var scope = application.Services.CreateScope();
        var userManager = scope
            .ServiceProvider
            .GetRequiredService<UserManager<ApplicationUser>>();

        var user = await userManager.FindByEmailAsync("admin@gmail.com");
        if (user == null)
        {
            user = new ApplicationUser();
            await userManager.SetEmailAsync(user, "admin@gmail.com");
            await userManager.SetUserNameAsync(user, user.Email);
            user.EmailConfirmed = true;

            await userManager.CreateAsync(user, "123456");

            var claim = new Claim(ClaimTypes.Role, "admin");
            await userManager.AddClaimAsync(user, claim);
        }
    }

}