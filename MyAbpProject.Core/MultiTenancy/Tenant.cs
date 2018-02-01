using Abp.MultiTenancy;
using MyAbpProject.Authorization.Users;

namespace MyAbpProject.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {
            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}