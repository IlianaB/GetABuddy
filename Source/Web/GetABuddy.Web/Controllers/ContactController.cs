namespace GetABuddy.Web.Controllers
{
    using System.Web.Mvc;

    public class ContactController : Controller
    {
        public ActionResult Info()
        {
            return this.View();
        }
    }
}