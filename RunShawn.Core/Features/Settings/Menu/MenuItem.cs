﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunShawn.Core.Features.Settings.Menu
{
    public class MenuItem
    {
        public long Id { get; set; }
        public long? ParentId { get; set; }
        public int Order { get; set; }
        public long PageId { get; set; }
        public string Icon { get; set; }
    }
}
