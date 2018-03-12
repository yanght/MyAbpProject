using MyAbpProject.Recharge;
using MyAbpProject.Systems;
using MyAbpProject.Systems.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyAbpProject.Web.Controllers
{
    public class SystemsController : MyAbpProjectControllerBase
    {
        private readonly ISystemAppService _systemsAppService;
        private readonly IRechargeAppService _rechargeAppService;
        public SystemsController(ISystemAppService systemsAppService, IRechargeAppService rechargeAppService)
        {
            _systemsAppService = systemsAppService;
            _rechargeAppService = rechargeAppService;
        }
        // GET: System
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Audited()
        {
            return View();
        }

        public JsonResult AuditLogs(GetAuditLogsInput input)
        {
            input.PageIndex = input.SkipCount;
            input.SkipCount = (input.SkipCount - 1) * input.MaxResultCount;
            var result = _systemsAppService.GetAuditLogsByPage(input);

            return AbpJson(new { code = 0, msg = string.Empty, count = result.TotalCount, data = result.Items }, wrapResult: false, behavior: JsonRequestBehavior.AllowGet);
        }

        public JsonResult Test()
        {
            var data = _rechargeAppService.GetRechargeRecordList(new Recharge.Dtos.GetRechargeRecordListInput());

            return AbpJson(data, behavior: JsonRequestBehavior.AllowGet);
        }
    }
}