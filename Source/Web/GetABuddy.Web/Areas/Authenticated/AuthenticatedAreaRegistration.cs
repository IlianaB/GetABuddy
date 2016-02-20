using System.Web.Mvc;

namespace MvcTemplate.Web.Areas.Authenticated
{
    public class AuthenticatedAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Authenticated";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Authenticated_default",
                "Authenticated/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}