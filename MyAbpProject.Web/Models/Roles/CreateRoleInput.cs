using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyAbpProject.Web.Models.Roles
{
    public class CreateRoleInput
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public bool IsStatic { get; set; }
    }
}