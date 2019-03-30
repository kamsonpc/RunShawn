using RunShawn.Core.Features.Users.Model;
using System.Collections.Generic;

namespace RunShawn.Core.Features.Users
{
    public interface IUsersService
    {
        #region GetAll()
        List<User> GetAll();
        #endregion

        #region GetById()
        User GetById(string id);
        #endregion

        #region Update()
        User Update(User model);
        #endregion

        #region SetAvatar
        void SetAvatar(string id, byte[] avatar);
        #endregion

        #region Delete()
        void Delete(string id);
        #endregion
    }
}
