using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Localization;
using Abp.MultiTenancy;
using System.Linq;
using System.Linq.Dynamic;
using Abp.Extensions;
using Abp.Linq.Extensions;


namespace MyAbpProject.Authorization
{
    public class MyAbpProjectAuthorizationProvider : AuthorizationProvider
    {
       
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);


        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, MyAbpProjectConsts.LocalizationSourceName);
        }
    }
}
