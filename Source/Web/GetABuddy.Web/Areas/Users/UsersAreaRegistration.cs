namespace GetABuddy.Web.Areas.Users
{
    using System.Web.Mvc;

    public class UsersAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Users";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.Routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            context.MapRoute(
                "Users_default",
                "Users/{controller}/{action}/{id}",
                new { area = "Users", action = "Index", id = UrlParameter.Optional },
                new[] { "GetABuddy.Web.Areas.Users.Controllers" }
             );
        }
    }
}