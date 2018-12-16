using System.Collections.Generic;
using RunShawn.Core.Features.Competition.Models;
using Simple.Data;

namespace RunShawn.Core.Features.Competition
{
    public class CompetitorsService
    {
        #region GetAll()
        public static List<Competitor> GetAll()
        {
            return Database.Open().Books.ToList();
        }
        #endregion
    }
}
