using RunShawn.Core.Features.Users;
using System.Web;
using System.Web.Mvc;

namespace RunShawn.Web.Extentions.Attributes
{
    public class AuthorizeUserAttribute : AuthorizeAttribute
    {
        public string AccessLevel { get; set; }
        private readonly IUsersService _usersService;

        public AuthorizeUserAttribute(IUsersService usersService)
        {
            _usersService = usersService;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var isAuthorized = base.AuthorizeCore(httpContext);
            if (!isAuthorized)
            {
                return false;
            }

            return false;
            // return privilegeLevels.Contains(AccessLevel);
        }
    }
}