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

        #region GetById()
        public static User GetByUsername(string username)
        {
            return Database.Open().AspNetUsers.Find(Database.Open().AspNetUsers.UserName == username);
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

        #region SetAvatar
        public static void SetAvatar(string id, byte[] avatar)
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

        #endregion


        #region SetScores()
        public static void SetScores(string id, long scores, bool adding = true)
        {
            var db = Database.Open();
            User user = db.AspNetUsers.FindById(id);

            if (user.Scores == null)
            {
                user.Scores = 0;
            }

            if (adding)
            {
                scores += user.Scores.Value;
            }
            else
            {
                scores -= user.Scores.Value;
                if (scores < 0)
                {
                    scores = 0;
                }
            }

            var sql = @"
                       UPDATE  AspNetUsers 
                       SET 
                            Scores = @scores
                       WHERE 
                            Id = @id";

            var rows = db.Execute(sql,
                new
                {
                    id,
                    scores
                });

        }
        #endregion

        #region SetScores()
        public static void ChangeScores(string id, long scores)
        {
            var db = Database.Open();

            User user = db.AspNetUsers.FindById(id);
            user.Scores = scores;
            db.AspNetUsers.UpdateById(user);

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
