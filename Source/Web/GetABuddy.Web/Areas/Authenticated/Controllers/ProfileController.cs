namespace GetABuddy.Web.Areas.Authenticated.Controllers
{
    using System.Web.Mvc;

    using Web.Controllers;

    public class ProfileController : BaseController
    {
        // GET: Users/Profile
        public ActionResult ById()
        {
            return View();
        }
    }
}