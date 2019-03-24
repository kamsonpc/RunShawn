using System;

namespace RunShawn.Core.Features.Activity.Models
{
    public class UserActivity
    {
        public long Id { get; set; }

        public long LocationId { get; set; }

        public string UserId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

    }
}
