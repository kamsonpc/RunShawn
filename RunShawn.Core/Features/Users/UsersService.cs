using RunShawn.Core.Features.Users.Model;
using Simple.Data;
using Simple.Data.RawSql;
using System.Collections.Generic;

namespace RunShawn.Core.Features.Users
{
    public class UsersService : IUsersService
    {
        #region GetAll()

        public List<User> GetAll()
        {
            return Database.Open().AspNetUsers.All();
        }

        #endregion GetAll()

        #region GetById()

        public User GetById(string id)
        {
            return Database.Open().AspNetUsers.FindById(id);
        }

        #endregion GetById()

        #region Update()

        public User Update(User model)
        {
            Database db = Database.Open();

            const string sql = @"
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

        #endregion Update()

        #region SetAvatar

        public void SetAvatar(string id, byte[] avatar)
        {
            Database db = Database.Open();
            var sql = @"
                       UPDATE  AspNetUsers
                       SET
                            Avatar = @avatar
                       WHERE
                            Id = @id";

            var rows = db.Execute(sql,
                new
                {
                    id,
                    avatar
                });
        }

        #endregion SetAvatar

        #region Delete()

        public void Delete(string id)
        {
            Database.Open().AspNetUsers.DeleteById(id);
        }

        #endregion Delete()
    }
}