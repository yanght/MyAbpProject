using Abp.Web.Models;
using Abp.WebApi.Controllers;
using MyAbpProject.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Abp.Web.Mvc.Controllers.Results;
using Abp.Application.Services.Dto;
using MyAbpProject.Roles.Dto;

namespace MyAbpProject.Api.Controllers
{
    public class HomeController : AbpApiController
    {
        private readonly IUserAppService _userAppService;
        public HomeController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }


        public Task<ListResultDto<RoleDto>> GetUsers()
        {
            var roles = _userAppService.GetRoles();

            return roles;
        }
    }
}
