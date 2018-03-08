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
     
        }
        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, MyAbpProjectConsts.LocalizationSourceName);
        }
    }
}
