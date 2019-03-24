using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using RunShawn.Web.Areas.Admin.Models;
using RunShawn.Web.Areas.Default.Models;
using RunShawn.Web.Extentions;
using RunShawn.Web.Models;

[assembly: OwinStartupAttribute(typeof(RunShawn.Web.Startup))]
namespace RunShawn.Web
{
    public partial class Startup
    {
        private string _email = "admin@runshawn.com";
        private string _password = "zaq1@WSX";

        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesandUsers();

            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<AdminMapProfile>();
                cfg.AddProfile<DefaultMapProfile>();
            });
        }

        private void CreateRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


            if (!roleManager.RoleExists(RoleTypes.Administrator.ToString()))
            {

                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole
                {
                    Name = RoleTypes.Administrator.ToString()
                };
                roleManager.Create(role);


                var user = new ApplicationUser
                {
                    UserName = _email,
                    Email = _email
                };

                string userPWD = _password;

                var chkUser = UserManager.Create(user, userPWD);

                if (chkUser.Succeeded)
                {
                    var result = UserManager.AddToRole(user.Id, RoleTypes.Administrator.ToString());

                }
            }

            if (!roleManager.RoleExists(RoleTypes.SuperUser.ToString()))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole
                {
                    Name = RoleTypes.SuperUser.ToString()
                };
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists(RoleTypes.Customer.ToString()))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole
                {
                    Name = RoleTypes.Customer.ToString()
                };
                roleManager.Create(role);
            }

        }
    }
}
