namespace GetABuddy.Web.Controllers
{
    using System.Web.Mvc;

    using Data.Models;
    using Microsoft.AspNet.Identity;
    using Services.Data;
    using ViewModels.EventDetails;

    public class EventController : BaseController
    {
        private readonly IEventsService events;
        private readonly ICommentsService comments;
        private readonly IUserServices users;

        public EventController(IEventsService events, ICommentsService comments, IUserServices users)
        {
            this.events = events;
            this.comments = comments;
            this.users = users;
        }

        public ActionResult ById(string id)
        {
            var eventById = this.events.GetById(id);
            var viewModel = this.Mapper.Map<EventDetailsViewModel>(eventById);

            return this.View(viewModel);
        }

        [HttpPost]
        public PartialViewResult AddComment(string content, string id)
        {
            var eventById = this.events.GetById(id);
            string authorId = string.Empty;

            if (this.User.Identity.IsAuthenticated)
            {
                authorId = this.User.Identity.GetUserId();
            }

            int intId = 1;
            int.TryParse(id, out intId);
            var newComment = this.comments.Create(content, intId, authorId);

            this.events.AddComment(eventById, newComment);

            var viewModel = this.Mapper.Map<EventDetailsViewModel>(eventById);

            return this.PartialView("_Comments", viewModel);
        }

        [HttpPost]
        public ActionResult Join(string id)
        {
            string currentUserId = this.User.Identity.GetUserId();
            ApplicationUser currentUser = this.users.GetById(currentUserId);
            this.events.AddParticipant(id, currentUser);

            this.TempData["Notification"] = "Thank you for your feedback!";
            return this.RedirectToAction("/ById/" + id);
        }

        [HttpGet]
        public ActionResult Create(string id)
        {
            return this.View();
        }
    }
}