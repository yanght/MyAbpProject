namespace MyAbpProject.Authorization
{
    public static class PermissionNames
    {
        public const string Pages_Tenants = "Pages.Tenants";


        #region 角色管理
        public const string Pages_Roles = "Pages.Roles";
        public const string Pages_Roles_Create = "Pages.Roles.Create";
        public const string Pages_Roles_Update = "Pages.Roles.Update";
        public const string Pages_Roles_Delete = "Pages.Roles.Delete";

        #endregion

        #region 用户管理
        public const string Pages_Users = "Pages.Users";
        public const string Pages_Users_Create = "Pages.Users.Create";
        public const string Pages_Users_Update = "Pages.Users.Update";
        public const string Pages_Users_Detele = "Pages.Users.Detele";
        #endregion
    }
}