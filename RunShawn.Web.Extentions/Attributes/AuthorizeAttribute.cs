using RunShawn.Web.Extentions.Roles;
using System;
using System.Web;
using System.Web.Mvc;

namespace RunShawn.Web.Extentions.Attributes
{
    public class AuthorizedRoleAttribute : AuthorizeAttribute
    {
        #region ctor

        public AuthorizedRoleAttribute(string role)
        {
            Role = role;
        }

        #endregion ctor

        #region AuthorizeCore

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return Role == RoleTypes.Administrator.ToString();
        }

        #endregion AuthorizeCore

        #region HandleUnauthorizedRequest()

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            base.HandleUnauthorizedRequest(filterContext);
        }

        #endregion HandleUnauthorizedRequest()

        public string Role { get; private set; }
    }

    public class AuthorizedAttribute : AuthorizeAttribute
    {
        #region AuthorizedAttribute()

        public AuthorizedAttribute(params RoleTypes[] roles) : base()
        {
            Roles = String.Join(",", Enum.GetNames(typeof(RoleTypes)));
        }

        #endregion AuthorizedAttribute()
    }
}