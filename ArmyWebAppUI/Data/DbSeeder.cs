using Microsoft.AspNetCore.Identity;
using ArmyWebAppUI.Constans;


namespace ArmyWebAppUI.Data
{
    public class DbSeeder
    {
        public static async Task SeedDefaultData(IServiceProvider service) {

            var userMgr = service.GetService<UserManager<IdentityUser>>();
            var roleMgr = service.GetService<RoleManager<IdentityRole>>();

            //jogadás a dbhez

            await roleMgr.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            await roleMgr.CreateAsync(new IdentityRole(Roles.User.ToString()));

            // admin létrehozasa

            var admin = new IdentityUser
            {
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                EmailConfirmed = true

            };

            var userInDb = await userMgr.FindByEmailAsync(admin.Email);

            if (userInDb is null)
            {
                await userMgr.CreateAsync(admin,"Admin_01");
                await userMgr.AddToRoleAsync(admin,Roles.Admin.ToString());

            }
        }

    }
}
