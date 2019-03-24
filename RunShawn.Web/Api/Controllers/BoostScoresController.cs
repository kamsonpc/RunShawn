using RunShawn.Web.Api.Model.Request.BoostPoints;
using System.Web.Http;

namespace RunShawn.Web.Api.Controllers
{
    public class BoostScoresController : ApiController
    {
        // GET: api/BoostScores
        public string Post([FromBody]BoostPointsRequest request)
        {
            return "ok";
        }
    }
}
