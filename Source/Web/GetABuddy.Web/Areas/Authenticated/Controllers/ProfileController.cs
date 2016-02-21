namespace GetABuddy.Web.Areas.Authenticated.Controllers
{
    using Services.Data;
    using System.Web.Mvc;

    using Web.Controllers;

    public class ProfileController : BaseController
    {
        private readonly IUserServices users;
        // GET: Users/Profile
        public ActionResult ById(string id)
        {
            return View();
        }
    }
}