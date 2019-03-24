using RunShawn.Core.Features.Activity.Models;
using RunShawn.Core.Features.Users.Model;
using Simple.Data;
using System;

namespace RunShawn.Core.Features.Activity
{
    public static class ActivityService
    {
        public static void BoostPoints(string userId, long locationId)
        {
            var db = Database.Open();
            LocationObject location = db.Activity.Locations.FindById(locationId);
            User user = db.dbo.AspNetUsers.FindById(userId);
            UserActivity userActivity = db.Activity.UsersActivity
                                          .Find(
                                                db.Activity.UsersActivity.UserId == userId,
                                                db.Activity.UsersActivity.Location == locationId,
                                                db.Activity.UsersActivity.StartDate.Date == DateTime.Now.Date
                                            );

            if (userActivity == null)
            {
                db.Activity.UsersActivity.Insert(new UserActivity
                {
                    StartDate = DateTime.Now,
                    LocationId = locationId,
                    UserId = userId
                });
            }
            else
            {
                user.Scores += location.Boost;

            }
        }

    }
}
