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
        public SystemsController(ISystemAppService systemsAppService)
        {
            _systemsAppService = systemsAppService;
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
            input.SkipCount = (input.SkipCount - 1) * input.MaxResultCount;
            var result = _systemsAppService.GetAuditLogs(input);

            return AbpJson(new { code = 0, msg = string.Empty, count = result.TotalCount, data = result.Items }, wrapResult: false, behavior: JsonRequestBehavior.AllowGet);
        }
    }
}