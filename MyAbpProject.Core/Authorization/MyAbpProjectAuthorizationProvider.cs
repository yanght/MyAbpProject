using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace MyAbpProject.Authorization
{
    public class MyAbpProjectAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            var users = context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);

            users.CreateChildPermission("pages_users_create", L("pages_users_create"));
            users.CreateChildPermission("pages_users_delete", L("pages_users_delete"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, MyAbpProjectConsts.LocalizationSourceName);
        }
    }
}
