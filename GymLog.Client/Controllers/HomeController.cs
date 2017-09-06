using System.Web.Mvc;

namespace GymLog.Client.Controllers {

    [RequireHttps]
    public class HomeController : Controller {

        public ActionResult Index() {
            return View();
        }
    }
}