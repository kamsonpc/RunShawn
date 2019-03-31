using RunShawn.Core.Features.Users.Model;
using System.Collections.Generic;

namespace RunShawn.Core.Features.Users
{
    public interface IUsersService
    {
        #region GetAll()

        List<User> GetAll();

        #endregion GetAll()

        #region GetById()

        User GetById(string id);

        #endregion GetById()

        #region Update()

        User Update(User model);

        #endregion Update()

        #region SetAvatar

        void SetAvatar(string id, byte[] avatar);

        #endregion SetAvatar

        #region Delete()

        void Delete(string id);

        #endregion Delete()
    }
}