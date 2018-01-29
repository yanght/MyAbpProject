using System.Web.Mvc;

namespace MyProject.Web.Controllers
{
    public class HomeController : MyProjectControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}