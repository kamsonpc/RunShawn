using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RunShawn.Web.Extentions;

namespace RunShawn.Web.Attributes
{

    public class AuthorizedRoleAttribute : AuthorizeAttribute
    {
        public AuthorizedRoleAttribute(string role)
        {
            Role = role;
        }
        protected override bool AuthorizeCore(HttpContextBase piHttpContext)
        {
            return Role == "Admin";
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext piFilterContext)
        {
            base.HandleUnauthorizedRequest(piFilterContext);

        }

        public string Role { get; private set; }
    }

    public class AuthorizedAttribute : AuthorizeAttribute
    {

        public AuthorizedAttribute(params RoleTypes[] roles) : base()
        {

            Roles = String.Join(",", Enum.GetNames(typeof(RoleTypes)));

        }

    }
}