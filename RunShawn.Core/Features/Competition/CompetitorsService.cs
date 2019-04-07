using RunShawn.Core.Features.Competition.Models;
using Simple.Data;
using System.Collections.Generic;

namespace RunShawn.Core.Features.Competition
{
    public static class CompetitorsService
    {
        #region GetAll()

        public static List<Competitor> GetAll()
        {
            return Database.Open().Books.ToList();
        }

        #endregion GetAll()
    }
}