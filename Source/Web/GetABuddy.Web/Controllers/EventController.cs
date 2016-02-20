namespace GetABuddy.Web.Controllers
{
    using System.Web.Mvc;

    using Services.Data;
    using ViewModels.EventDetails;

    public class EventController : BaseController
    {
        private readonly IEventsService events;

        public EventController(IEventsService events)
        {
            this.events = events;
        }

        public ActionResult ById(string id)
        {
            var eventById = this.events.GetById(id);
            var viewModel = this.Mapper.Map<EventDetailsViewModel>(eventById);

            return this.View(viewModel);
        }
    }
}