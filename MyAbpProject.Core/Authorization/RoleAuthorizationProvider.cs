using Abp.Authorization;
using Abp.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAbpProject.Authorization
{
    public class RoleAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            var roles = context.CreatePermission(PermissionNames.Pages_Roles, L("Permission_Roles"));
            roles.CreateChildPermission(PermissionNames.Pages_Roles_Create, L("Permission_Roles_Create"));
            roles.CreateChildPermission(PermissionNames.Pages_Roles_Update, L("Permission_Roles_Update"));
            roles.CreateChildPermission(PermissionNames.Pages_Roles_Delete, L("Permission_Roles_Delete"));
        }
        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, MyAbpProjectConsts.LocalizationSourceName);
        }
    }
}
