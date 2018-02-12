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
using MyAbpProject.Recharge;
using MyAbpProject.Recharge.Dtos;

namespace MyAbpProject.Api.Controllers
{
    public class HomeController : AbpApiController
    {
        private readonly IUserAppService _userAppService;
        private readonly IRechargeAppService _rechargeAppService;
        public HomeController(IUserAppService userAppService,
            IRechargeAppService rechargeAppService)
        {
            _userAppService = userAppService;
            _rechargeAppService = rechargeAppService;
        }


        public Task<ListResultDto<RoleDto>> GetUsers()
        {
            var roles = _userAppService.GetRoles();

            return roles;
        }

        public AjaxResponse RechargeRecores()
        {
            var records = _rechargeAppService.GetRechargeRecordList(new GetRechargeRecordListInput());
           
            return new AjaxResponse(records);
        }
    }
}
