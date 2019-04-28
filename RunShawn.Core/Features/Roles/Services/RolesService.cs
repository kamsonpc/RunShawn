using RunShawn.Core.Features.Roles.Model;
using RunShawn.Core.Features.Roles.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RunShawn.Core.Features.Roles.Services
{
    public class RolesService : IRolesService
    {
        #region DI
        private readonly IPermissionsRepository _permissionsRepository;
        private readonly IRolesRepository _rolesRepository;

        public RolesService(IPermissionsRepository permissionsRepository, IRolesRepository rolesRepository)
        {
            _permissionsRepository = permissionsRepository;
            _rolesRepository = rolesRepository;
        }
        #endregion

        #region SetUpRoleInDb()
        public void BuildPermissions(List<Permission> permissions)
        {
            _permissionsRepository.DeleteAll();
            _rolesRepository.DeleteAllUserRolesConnection();

            _permissionsRepository.InsertMany(permissions);
        }
        #endregion

        #region GeneratePermissions()
        public List<Permission> GeneratePermissions(Dictionary<int, string> data)
        {
            var permissions = new List<Permission>();
            foreach (var permission in data)
            {
                permissions.Add(new Permission
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = permission.Value,
                    Value = permission.Key
                });
            }
            return permissions;
        }
        #endregion

        #region IsNeedRebuildPermissions
        public bool IsNeedRebuildPermissions(List<Permission> permissions)
        {
            var permissionsInDb = _permissionsRepository.GetAll();
            permissionsInDb = permissionsInDb.Select(x => new Permission { Title = x.Title, Value = x.Value }).ToList();
            permissions = permissions.Select(x => new Permission { Title = x.Title, Value = x.Value }).ToList();

            var diff = permissionsInDb.Except(permissions);

            return diff.Count() > 0;
        }
        #endregion
    }
}