using System.Web.Mvc;

namespace MyAbpProject.Web.Controllers
{
    public class AboutController : MyAbpProjectControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}