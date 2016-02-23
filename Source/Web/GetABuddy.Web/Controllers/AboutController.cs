namespace GetABuddy.Web.Controllers
{
    using System.Web.Mvc;

    public class AboutController : Controller
    {
        public ActionResult Info()
        {
            return this.View();
        }
    }
}