using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Localization;
using Abp.MultiTenancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAbpProject.Authorization
{
    public class UserAuthorizationProvider : AuthorizationProvider
    {

        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            var users = context.CreatePermission(PermissionNames.Pages_Users, L("Permission_Users"));
           
            users.CreateChildPermission(PermissionNames.Pages_Users_Create, L("Permission_Users_Create"));
            users.CreateChildPermission(PermissionNames.Pages_Users_Update, L("Permission_Users_Update"));
            users.CreateChildPermission(PermissionNames.Pages_Users_Detele, L("Permission_Users_Delete"));
        }
        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, MyAbpProjectConsts.LocalizationSourceName);
        }
    }
}
