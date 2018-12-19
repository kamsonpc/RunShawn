using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
}