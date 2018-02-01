using System.Collections.Generic;
using MyAbpProject.Roles.Dto;
using MyAbpProject.Users.Dto;

namespace MyAbpProject.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<UserDto> Users { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}