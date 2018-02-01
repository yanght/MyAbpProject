using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;

namespace MyAbpProject.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : MyAbpProjectControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}