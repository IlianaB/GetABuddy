namespace GetABuddy.Web.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    using Data.Models;
    using Microsoft.AspNet.Identity;
    using Services.Data;
    using ViewModels.Event;
    using ViewModels.EventDetails;

    public class EventController : BaseController
    {
        private readonly IEventsService events;
        private readonly ICommentsService comments;
        private readonly IUserServices users;
        private readonly ICategoriesService categories;
        private readonly ICitiesService cities;

        public EventController(
            IEventsService events,
            ICommentsService comments,
            IUserServices users,
            ICategoriesService categories,
            ICitiesService cities)
        {
            this.events = events;
            this.comments = comments;
            this.users = users;
            this.categories = categories;
            this.cities = cities;
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
        [Authorize]
        public ActionResult Create(string id)
        {
            var categories = this.categories.GetAll();
            var cities = this.cities.GetAll();
            var categoriesViewModel = this.Mapper.Map<IEnumerable<CategoryViewModel>>(categories);
            var citiesViewModel = this.Mapper.Map<IEnumerable<CityViewModel>>(cities);

            var model = new CreateEventViewModel()
            {
                Categories = categoriesViewModel,
                Cities = citiesViewModel,
                Event = new InputEventViewModel()
            };

            return this.View(model);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InputEventViewModel eventToCreate)
        {
            var authorId = this.User.Identity.GetUserId();

            var newEvent = this.events.Create(
                eventToCreate.Name,
                eventToCreate.Description,
                eventToCreate.Time,
                eventToCreate.NumberOfParticipants,
                eventToCreate.CityId,
                eventToCreate.CategoryId,
                authorId);

            return this.RedirectToAction("/ById/" + newEvent.Id);
        }

        [HttpGet]
        [Authorize]
        public ActionResult MyEvents()
        {
            var authorId = this.User.Identity.GetUserId();
            var events = this.events.GetAll();
            var viewModel = this.Mapper.Map<IEnumerable<MyEventsViewModel>>(events);

            return this.View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MyEventsViewModel input)
        {
            var ev = this.events.Update(input.Id.ToString(), input.Name, input.Description, input.Time, input.NumberOfParticipants);

            return this.RedirectToAction("/MyEvents");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(MyEventsViewModel input)
        {
            this.events.Delete(input.Id.ToString());

            return this.RedirectToAction("/MyEvents");
        }
    }
}