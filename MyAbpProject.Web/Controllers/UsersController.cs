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
    [AbpMvcAuthorize(PermissionNames.Pages_Users)]
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

        public JsonResult UserList(GetUsersInput input)
        {
            //var users = (await _userAppService.GetAll(new PagedResultRequestDto { MaxResultCount = int.MaxValue })).Items; //Paging not implemented yet

            input.SkipCount = (input.SkipCount - 1) * input.MaxResultCount;

            var result = _userAppService.GetUserByPage(input);

            return AbpJson(new { code = 0, msg = string.Empty, count = result.TotalCount, data = result.Items }, wrapResult: false, behavior: JsonRequestBehavior.AllowGet);
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

        public async Task<ActionResult> EditUser(long userId)
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

        [AbpMvcAuthorize(PermissionNames.Pages_Users_Create)]
        [HttpPost]
        public async Task<JsonResult> AddUser(Users.Dto.CreateUserDto user)
        {
            UserDto reult = await _userAppService.Create(user);

            return AbpJson(reult);
        }

        [AbpMvcAuthorize(PermissionNames.Pages_Roles_Update)]
        [HttpPost]
        public async Task<JsonResult> UpdateUser(UpdateUserDto user)
        {
            UserDto reult = await _userAppService.Update(user);

            return AbpJson(reult);
        }

        [AbpMvcAuthorize(PermissionNames.Pages_Users_Detele)]
        [HttpPost]
        public async Task<JsonResult> DeleteUser(long userId)
        {
            await _userAppService.Delete(new EntityDto<long>() { Id = userId });
            return AbpJson(Task.FromResult(true));
        }
    }
}