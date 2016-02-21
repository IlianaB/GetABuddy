namespace GetABuddy.Web.Areas.Users.Controllers
{
    using System.Web.Mvc;

    using Services.Data;
    using ViewModels;
    using Web.Controllers;

    public class ProfileController : BaseController
    {
        private readonly IUserServices users;

        public ProfileController(IUserServices users)
        {
            this.users = users;
        }

        [HttpGet]
        public ActionResult ByUserName(string name)
        {
            var user = this.users.GetByUserName(name);
            var viewModel = this.Mapper.Map<UserInfoViewModel>(user);

            return this.View(viewModel);
        }
    }
}