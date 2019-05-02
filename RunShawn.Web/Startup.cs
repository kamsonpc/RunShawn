﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using RunShawn.Core.Features.Roles;
using RunShawn.Core.Features.Roles.Repository;
using RunShawn.Core.Features.Roles.Services;
using RunShawn.Core.Helpers.Enums;
using RunShawn.Web.Areas.General.Models;
using RunShawn.Web.Extentions.Roles;

[assembly: OwinStartupAttribute(typeof(RunShawn.Web.Startup))]

namespace RunShawn.Web
{
    public partial class Startup
    {
        private readonly string _email = "admin@runshawn.com";
        private readonly string _password = "zaq1@WSX";

        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            InitializePermissions();
            CreateDefaultUsers();
        }

        private void CreateDefaultUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            if (!roleManager.RoleExists(nameof(RoleTypes.Administrator)))
            {
                var role = new IdentityRole
                {
                    Name = nameof(RoleTypes.Administrator)
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
                    var result = UserManager.AddToRole(user.Id, nameof(RoleTypes.Administrator));
                }
            }

            if (!roleManager.RoleExists(nameof(RoleTypes.SuperUser)))
            {
                var role = new IdentityRole
                {
                    Name = nameof(RoleTypes.SuperUser)
                };
                roleManager.Create(role);
            }
        }

        private void InitializePermissions()
        {
            var roleService = new RolesService(new PermissionsRepository(), new RolesRepository());
            var permissions = roleService.GeneratePermissions(EnumUtil.ToDictionary<GeneralPermissions>());
            if (roleService.IsNeedRebuildPermissions(permissions))
            {
                roleService.BuildPermissions(permissions);
            }
        }
    }
}