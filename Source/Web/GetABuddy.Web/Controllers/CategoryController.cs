namespace GetABuddy.Web.Controllers
{
    using System.Web.Mvc;

    using Services.Data;

    public class CategoryController : BaseController
    {
        private readonly ICategoriesService categories;

        public CategoryController(ICategoriesService categories)
        {
            this.categories = categories;
        }

        public ActionResult All()
        {
            var categories = this.categories.GetAll();
            var viewModel = this.Mapper.Map<EventDetailsViewModel>(categories);

            return this.View(viewModel);
        }

        public ActionResult ById(string id)
        {
            var eventById = this.events.GetById(id);
            var viewModel = this.Mapper.Map<EventDetailsViewModel>(eventById);

            return this.View(viewModel);
        }
    }
}