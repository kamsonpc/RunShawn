using RunShawn.Core.Features.Users.Repositories;
using System.Web;
using System.Web.Mvc;

namespace RunShawn.Web.Extentions.Attributes
{
    public class AuthorizeUserAttribute : AuthorizeAttribute
    {
        public string AccessLevel { get; set; }
        private readonly IUsersRepository _usersRepository;

        public AuthorizeUserAttribute(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
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