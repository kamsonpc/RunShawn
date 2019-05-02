using RunShawn.Core.Base;
using RunShawn.Core.Features.Roles.Model;
using Simple.Data;
using System;
using System.Collections.Generic;

namespace RunShawn.Core.Features.Roles.Repository
{
    public class RolesRepository : BaseRepository, IRolesRepository
    {
        #region GetAll()

        public List<Role> GetAll()
        {
            return Database.Open().AspNetRoles.All();
        }

        #endregion GetAll()

        #region GetByUser()

        public string GetByUser(string userId)
        {
            return Database.Open().AspNetUserRoles.FindByUserId(userId)?.RoleId;
        }

        #endregion GetByUser()

        #region Add()

        public Role Add(Role role)
        {
            try
            {
                return Database.Open().AspNetUserRoles.Insert(role);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }

        #endregion Add()

        #region Update()

        public Role Update(Role role)
        {
            try
            {
                return Database.Open().AspNetUserRoles.UpdateById(role);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }

        #endregion Update()

        #region Delete()

        public void Delete(string id)
        {
            try
            {
                Database.Open().AspNetUserRoles.DeleteById(id);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }

        #endregion Delete()

        #region SetRole()

        public void SetRole(UserRole userRole)
        {
            Database.Open().AspNetUserRoles.Insert(userRole);
        }

        #endregion SetRole()

        #region ChangeRole()

        public void ChangeRole(UserRole userRole)
        {
            Database.Open().AspNetUserRoles.DeleteByUserId(userRole.UserId);
            if (!string.IsNullOrEmpty(userRole.RoleId))
            {
                Database.Open().AspNetUserRoles.Insert(userRole);
            }
        }

        #endregion ChangeRole()

        #region DeleteAllUserRolesConnection()

        public void DeleteAllUserRolesConnection()
        {
            try
            {
                Database.Open().Permissions.RolesPermissions.DeleteAll();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }

        #endregion DeleteAllUserRolesConnection()
    }
}