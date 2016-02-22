namespace GetABuddy.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    using Web.Controllers;

    [Authorize(Roles = "Administrator")]
    public class AdministrationController : BaseController
    {
    }
}
