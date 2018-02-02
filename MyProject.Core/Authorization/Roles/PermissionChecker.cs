using Abp.Authorization;
using Microsoft.AspNet.Identity;
using MyProject.MultiTenancy;
using MyProject.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Authorization.Roles
{
    public class PermissionChecker : PermissionChecker< Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
