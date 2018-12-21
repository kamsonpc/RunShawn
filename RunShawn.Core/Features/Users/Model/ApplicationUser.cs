﻿using System;

namespace RunShawn.Core.Features.Users.Model
{
    public class User
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public DateTime? LockoutEndDateUTC { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }

    }
}
