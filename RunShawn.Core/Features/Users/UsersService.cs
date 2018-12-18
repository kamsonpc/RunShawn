using System.Collections.Generic;
using RunShawn.Core.Features.Users.Model;
using Simple.Data;

namespace RunShawn.Core.Features.Users
{
    public class UsersService
    {
        #region GetAll()
        public static List<User> GetAll()
        {
            return Database.Open().AspNetUsers.ToList();
        }
        #endregion
    }
}
