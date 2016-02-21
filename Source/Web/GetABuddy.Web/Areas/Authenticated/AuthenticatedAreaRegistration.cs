namespace MvcTemplate.Web.Areas.Authenticated
{
    using System.Web.Mvc;

    public class AuthenticatedAreaRegistration : AreaRegistration 
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
            context.MapRoute(
                "Authenticated_default",
                "Users/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}