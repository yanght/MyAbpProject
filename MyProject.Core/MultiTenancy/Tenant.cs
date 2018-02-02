using Abp.MultiTenancy;
using MyProject.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.MultiTenancy
{
    public class Tenant: AbpTenant<User>
    {

    }
}
