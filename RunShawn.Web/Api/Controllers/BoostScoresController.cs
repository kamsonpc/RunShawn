using RunShawn.Core.Features.Activity;
using RunShawn.Core.Features.Users;
using RunShawn.Web.Api.Model.Request.BoostPoints;
using System;
using System.Web.Http;

namespace RunShawn.Web.Api.Controllers
{
    public class BoostScoresController : ApiController
    {
        // GET: api/BoostScores
        public string Post([FromBody]BoostPointsRequest request)
        {
            try
            {
                ActivityService.BoostPoints(request.Login, request.LocationId);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "ok";
        }

        public long GetScores(string username)
        {
            var user = UsersService.GetByUsername(username);
            if (user.Scores.HasValue)
            {
                return user.Scores.Value;
            }
            return 0;
        }
    }
}
