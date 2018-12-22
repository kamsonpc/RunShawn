using RunShawn.Web.Extentions;
using System;
using System.Web;
using System.Web.Mvc;

namespace RunShawn.Web.Attributes
{

    public class AuthorizedRoleAttribute : AuthorizeAttribute
    {
        #region ctor
        public AuthorizedRoleAttribute(string role)
        {
            Role = role;
        }
        #endregion

        #region AuthorizeCore
        protected override bool AuthorizeCore(HttpContextBase piHttpContext)
        {
            return Role == RoleTypes.Administrator.ToString();
        }
        #endregion()

        #region HandleUnauthorizedRequest()
        protected override void HandleUnauthorizedRequest(AuthorizationContext piFilterContext)
        {
            base.HandleUnauthorizedRequest(piFilterContext);

        }
        #endregion

        public string Role { get; private set; }
    }

    public class AuthorizedAttribute : AuthorizeAttribute
    {
        #region AuthorizedAttribute()
        public AuthorizedAttribute(params RoleTypes[] roles) : base()
        {
            Roles = String.Join(",", Enum.GetNames(typeof(RoleTypes)));
        }
        #endregion
    }
}