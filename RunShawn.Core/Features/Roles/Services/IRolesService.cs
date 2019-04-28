using RunShawn.Core.Features.Roles.Model;
using System.Collections.Generic;

namespace RunShawn.Core.Features.Roles.Services
{
    public interface IRolesService
    {
        void BuildPermissions(List<Permission> permissions);
    }
}