using RunShawn.Core.Features.Roles.Model;
using System.Collections.Generic;

namespace RunShawn.Core.Features.Roles.Repositories
{
    public interface IPermissionsRepository
    {
        List<Permission> GetAll();

        Permission GetById(string id);

        Permission Add(Permission permission);

        void Delete(string Id);

        List<int> GetPermissionsByRole(string id);

        void InsertMany(List<Permission> permissions);

        void DeleteAll();
    }
}