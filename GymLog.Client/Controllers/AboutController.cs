using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Thinktecture.IdentityModel.Mvc;

namespace GymLog.Client.Controllers {
    [Authorize]
    public class AboutController : Controller {

        public ActionResult Index() {
            return View((User as ClaimsPrincipal).Claims);
        }

        public ActionResult Logout() {
            Request.GetOwinContext().Authentication.SignOut();
            return Redirect("/");
        }

        [ResourceAuthorize("Read", "ContactDetails")]
        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";

            return View();

        }
    }
}