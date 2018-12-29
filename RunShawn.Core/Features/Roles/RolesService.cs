using Simple.Data;
using System.Collections.Generic;

namespace RunShawn.Core.Features.Roles.Model
{
    public static class RolesService
    {
        #region GetAll()
        public static List<Role> GetAll()
        {
            return Database.Open().AspNetRoles.All();
        }
        #endregion

        #region GetByUser()
        public static string GetByUser(string userId)
        {
            return Database.Open().AspNetUserRoles.FindByUserId(userId)?.RoleId;
        }
        #endregion

        #region SetRole()
        public static void SetRole(string userId, string roleId)
        {
            var assign = new UserRoles
            {
                UserId = userId,
                RoleId = roleId
            };
            Database.Open().AspNetUserRoles.Insert(assign);
        }
        #endregion

        #region ChangeRole()
        public static void ChangeRole(string userId, string roleId)
        {
            Database.Open().AspNetUserRoles.DeleteByUserId(userId);
            if (!string.IsNullOrEmpty(roleId))
            {
                var assign = new UserRoles
                {
                    UserId = userId,
                    RoleId = roleId
                };
                Database.Open().AspNetUserRoles.Insert(assign);
            }
        }
        #endregion
    }
}
