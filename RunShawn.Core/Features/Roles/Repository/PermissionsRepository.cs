using RunShawn.Core.Base;
using RunShawn.Core.Features.Roles.Model;
using Simple.Data;
using System;
using System.Collections.Generic;

namespace RunShawn.Core.Features.Roles.Repository
{
    public class PermissionsRepository : BaseRepository, IPermissionsRepository
    {
        #region Add()

        public Permission Add(Permission permission)
        {
            try
            {
                return Database.Open().Permissions.Permissions.Insert(permission);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }

        #endregion Add()

        #region Delete()

        public void Delete(string Id)
        {
            try
            {
                Database.Open().Permissions.Permissions.DeleteById(Id);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }

        #endregion Delete()

        #region GetAll()

        public List<Permission> GetAll()
        {
            try
            {
                return Database.Open().Permissions.Permissions.All();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }

        #endregion GetAll()

        #region GetById()

        public Permission GetById(string id)
        {
            try
            {
                return Database.Open().Permissions.Permissions.FindById(id);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }

        #endregion GetById()

        #region GetPermissionsByUser()

        public List<int> GetPermissionsByRole(string id)
        {
            try
            {
                return Database.Open().Permissions.GetByRole(id);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }

        #endregion GetPermissionsByUser()

        #region InsertMany()

        public void InsertMany(List<Permission> permissions)
        {
            try
            {
                Database.Open().Permissions.Permissions.Insert(permissions);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }

        #endregion InsertMany()

        #region DeleteAll()

        public void DeleteAll()
        {
            try
            {
                Database.Open().Permissions.Permissions.DeleteAll();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }

        #endregion DeleteAll()
    }
}