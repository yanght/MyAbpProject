using System.Threading.Tasks;
using System.Web.Mvc;
using Abp.Application.Services.Dto;
using Abp.Web.Mvc.Authorization;
using MyAbpProject.Authorization;
using MyAbpProject.Roles;
using MyAbpProject.Roles.Dto;
using MyAbpProject.Web.Models.Roles;

namespace MyAbpProject.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Roles)]
    public class RolesController : MyAbpProjectControllerBase
    {
        private readonly IRoleAppService _roleAppService;

        public RolesController(IRoleAppService roleAppService)
        {
            _roleAppService = roleAppService;
        }


        public async Task<ActionResult> Index()
        {
            var roles = (await _roleAppService.GetAll(new PagedAndSortedResultRequestDto())).Items;
            var permissions = (await _roleAppService.GetAllPermissions()).Items;
            var model = new RoleListViewModel
            {
                Roles = roles,
                Permissions = permissions
            };

            return View(model);
        }

        public async Task<ActionResult> EditRoleModal(int roleId)
        {
            var role = await _roleAppService.Get(new EntityDto(roleId));
            var permissions = (await _roleAppService.GetAllPermissions()).Items;
            var model = new EditRoleModalViewModel
            {
                Role = role,
                Permissions = permissions
            };
            return View("_EditRoleModal", model);
        }

        public async Task<ActionResult> EditRole(int roleId = 0)
        {
            var role = await _roleAppService.Get(new EntityDto(roleId));
            var permissions = (await _roleAppService.GetAllPermissions()).Items;
            var model = new EditRoleModalViewModel
            {
                Role = role,
                Permissions = permissions
            };
            return View(model);
        }

        public async Task<ActionResult> GetPermissions()
        {
            var permissions = (await _roleAppService.GetAllPermissions()).Items;
            return AbpJson(permissions, behavior: JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<ActionResult> AddRole(CreateRoleDto role)
        {
            RoleDto result = await _roleAppService.Create(role);

            return AbpJson(result);
        }
        [HttpPost]
        public async Task<ActionResult> UpdateRole(RoleDto role)
        {
            RoleDto result = await _roleAppService.Update(role);

            return AbpJson(result);
        }
        [HttpPost]
        public async Task<ActionResult> DeleteRole(int roleId = 0)
        {
            await _roleAppService.Delete(new EntityDto(roleId));
            return AbpJson(Task.FromResult(true));

        }

        public async Task<JsonResult> RolesList()
        {
            var roles = (await _roleAppService.GetAll(new PagedAndSortedResultRequestDto())).Items;
            return AbpJson(new { code = 0, msg = string.Empty, count = roles.Count, data = roles }, behavior: JsonRequestBehavior.AllowGet, wrapResult: false);
        }
    }
}