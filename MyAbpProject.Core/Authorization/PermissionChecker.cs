using Abp.Authorization;
using MyAbpProject.Authorization.Roles;
using MyAbpProject.Authorization.Users;

namespace MyAbpProject.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
