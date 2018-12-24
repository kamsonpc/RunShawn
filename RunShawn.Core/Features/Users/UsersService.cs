using RunShawn.Core.Features.Users.Model;
using Simple.Data;
using Simple.Data.RawSql;
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

        #region GetById()
        public static User GetById(string id)
        {
            return Database.Open().AspNetUsers.FindById(id);
        }
        #endregion

        #region Update()
        public static User Update(User model)
        {
            Database db = Database.Open();
            var sql = @"
                       UPDATE  AspNetUsers 
                       SET 
                            UserName = @username,
                            FirstName = @firstname,
                            LastName = @lastname,
                            Email = @email,
                            PhoneNumber = @phoneNumber,
                            LockoutEnabled = @lockoutEnabled,
                            LockoutEndDateUtc = @lockoutEndDateUtc     
                       WHERE 
                            Id = @id";

            var rows = db.Execute(sql,
                new
                {
                    id = model.Id,
                    username = model.UserName,
                    firstname = model.FirstName,
                    lastname = model.LastName,
                    email = model.Email,
                    phoneNumber = model.PhoneNumber,
                    lockoutEnabled = model.LockoutEnabled,
                    lockoutEndDateUtc = model.LockoutEndDateUtc
                });
            return model;
        }
        #endregion

        #region Delete()
        public static void Delete(string id)
        {
            Database.Open().AspNetUsers.DeleteById(id);
        }
        #endregion
    }
}
