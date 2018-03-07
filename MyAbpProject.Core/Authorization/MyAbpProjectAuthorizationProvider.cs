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
             context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);


            var recharges = context.CreatePermission("Pages.Recharge",L("Permission_Recharge"));
            recharges.CreateChildPermission("Pages.Recharge.Create", L("Permission_Recharge_Create"));
            recharges.CreateChildPermission("Pages.Recharge.Update", L("Permission_Recharge_Update"));
            recharges.CreateChildPermission("Pages.Recharge.Delete", L("Permission_Recharge_Delete"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, MyAbpProjectConsts.LocalizationSourceName);
        }
    }
}
