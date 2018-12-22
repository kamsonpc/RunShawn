using RunShawn.Core.Features.Users.Model;
using Simple.Data;
using System.Collections.Generic;

namespace RunShawn.Core.Features.Users
{
    public class UsersService
    {
        #region GetAll()
        public static List<User> GetAll()
        {
            return Database.Open().AspNetUsers.All();
        }
        #endregion
    }
}
