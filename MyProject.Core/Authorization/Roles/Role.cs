using Abp.Authorization.Roles;
using MyProject.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Authorization.Roles
{
    public class Role:AbpRole<User>
    {

    }
}
