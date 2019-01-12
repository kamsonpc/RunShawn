﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunShawn.Core.Features.Pages.Model
{
    public class Page
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public bool Active { get; set; }
        public string Content { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
