using RunShawn.Core.Features.Activity.Models;
using RunShawn.Core.Features.Users.Model;
using Simple.Data;
using System;

namespace RunShawn.Core.Features.Activity
{
    public static class ActivityService
    {
        public static void BoostPoints(string login, long locationId)
        {
            var db = Database.Open();
            LocationObject location = db.Activity.Locations.FindById(locationId);
            User user = db.dbo.AspNetUsers.Find(db.dbo.AspNetUsers.Username == login);
            UserActivity userActivity = db.Activity.UsersActivity
                                                   .Find(
                                                        db.Activity.UsersActivity.UserId == user.Id &&
                                                        db.Activity.UsersActivity.LocationId == locationId &&
                                                        db.Activity.UsersActivity.StartDate == DateTime.Now.Date &&
                                                        db.Activity.UsersActivity.EndDate == null
                                                    );

            if (userActivity == null)
            {
                db.Activity.UsersActivity.Insert(new UserActivity
                {
                    StartDate = DateTime.Now.Date,
                    LocationId = locationId,
                    UserId = user.Id
                });
            }
            else
            {
                if (userActivity.EndDate != null)
                {
                    return;
                }
                user.Scores += location.Boost;
                userActivity.EndDate = DateTime.Now.Date;
                db.Activity.UsersActivity.UpdateById(userActivity);
                db.dbo.AspNetUsers.UpdateById(user);
            }
        }

    }
}
