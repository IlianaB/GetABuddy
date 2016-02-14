namespace GetABuddy.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;
    
    using GetABuddy.Web.Controllers;

    [Authorize(Roles = "Administrator")]
    public class AdministrationController : BaseController
    {
    }
}
