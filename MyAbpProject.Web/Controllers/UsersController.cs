using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Dependency;
using Abp.Events.Bus.Exceptions;
using Abp.Events.Bus.Handlers;
using Abp.UI;
using Abp.Web.Models;
using Abp.Web.Mvc.Authorization;
using MyAbpProject.Authorization;
using MyAbpProject.Authorization.Roles;
using MyAbpProject.Roles.Dto;
using MyAbpProject.Users;
using MyAbpProject.Users.Dto;
using MyAbpProject.Web.Models.Users;

namespace MyAbpProject.Web.Controllers
{
    //[AbpMvcAuthorize(PermissionNames.Pages_Users)]
    public class UsersController : MyAbpProjectControllerBase
    {
        private readonly IUserAppService _userAppService;
        private readonly RoleManager _roleManager;

        public UsersController(IUserAppService userAppService, RoleManager roleManager)
        {
            _userAppService = userAppService;
            _roleManager = roleManager;
        }

        public async Task<ActionResult> Index()
        {
            var users = (await _userAppService.GetAll(new PagedResultRequestDto { MaxResultCount = int.MaxValue })).Items; //Paging not implemented yet
            var roles = (await _userAppService.GetRoles()).Items;
            var model = new UserListViewModel
            {
                Users = users,
                Roles = roles
            };

            return View(model);
        }

        public async Task<JsonResult> UserList()
        {
            var users = (await _userAppService.GetAll(new PagedResultRequestDto { MaxResultCount = int.MaxValue })).Items; //Paging not implemented yet

            return AbpJson(new { code = 0, msg = string.Empty, count = users.Count, data = users }, null, null, JsonRequestBehavior.AllowGet, false);
        }

        public async Task<ActionResult> EditUserModal(long userId)
        {
            var user = await _userAppService.Get(new EntityDto<long>(userId));
            var roles = (await _userAppService.GetRoles()).Items;
            var model = new EditUserModalViewModel
            {
                User = user,
                Roles = roles
            };
            return View("_EditUserModal", model);
        }

        public async Task<ActionResult> EditUser(long userId = 0)
        {
            var user = await _userAppService.Get(new EntityDto<long>(userId));
            var roles = (await _userAppService.GetRoles()).Items;
            var model = new EditUserModalViewModel
            {
                User = user,
                Roles = roles
            };
            return View(model);
        }

        [HttpPost]
        public async Task<JsonResult> AddUser(Users.Dto.CreateUserDto user)
        {
            UserDto reult = await _userAppService.Create(user);

            return AbpJson(reult);
        }
    }
}