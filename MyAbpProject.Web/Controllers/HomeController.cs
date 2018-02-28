using System.Web.Mvc;
using Abp.Threading;
using Abp.Web.Mvc.Authorization;
using MyAbpProject.Sessions;
using MyAbpProject.Sessions.Dto;

namespace MyAbpProject.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : MyAbpProjectControllerBase
    {
        private readonly ISessionAppService _sessionAppService;

        public HomeController(ISessionAppService sessionAppService)
        {
            _sessionAppService = sessionAppService;
        }

        public ActionResult Index()
        {
            GetCurrentLoginInformationsOutput model = AsyncHelper.RunSync(() => _sessionAppService.GetCurrentLoginInformations());

            return View(model);
        }
    }
}