using Enigma_Digital.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Enigma_Digital.Startup))]
namespace Enigma_Digital
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRoleAndUser();
        }

        private void CreateRoleAndUser()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var rolManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!rolManager.RoleExists("Admin"))
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                rolManager.Create(role);

                var user = new ApplicationUser();
                user.UserName = "jonathan@unan.edu.ni";
                user.Email = "jonathan@unan.edu.ni";
                string PDW = "123456";

                var chkUser = userManager.Create(user, PDW);
                if (chkUser.Succeeded)
                {
                    var result = userManager.AddToRole(user.Id, "Admin");
                }
            }

            if (!rolManager.RoleExists("Invitado"))
            {
                var role = new IdentityRole();
                role.Name = "Invitado";
                rolManager.Create(role);

                var user = new ApplicationUser();
                user.UserName = "osmar@unan.edu.ni";
                user.Email = "osmar@unan.edu.ni";
                string PDW = "123456";

                var chkUser = userManager.Create(user, PDW);
                if (chkUser.Succeeded)
                {
                    var result = userManager.AddToRole(user.Id, "Invitado");
                }
            }

        }

    }
}
