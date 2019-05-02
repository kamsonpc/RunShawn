using RunShawn.Core.Features.Roles.Model;
using System.Collections.Generic;

namespace RunShawn.Core.Features.Roles.Repository
{
    public interface IRolesRepository
    {
        List<Role> GetAll();

        Role Add(Role role);

        void Delete(string id);

        string GetByUser(string userId);

        Role Update(Role role);

        void ChangeRole(UserRole userRole);

        void SetRole(UserRole userRole);

        void DeleteAllUserRolesConnection();
    }
}