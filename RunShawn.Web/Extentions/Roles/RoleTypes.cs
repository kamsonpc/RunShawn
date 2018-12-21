using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace RunShawn.Web.Extentions
{
    public enum RoleTypes
    {
        [Description("Administrator")]
        Administrator = 10,

        [Description("Manager")]
        Manager = 20
    }
}