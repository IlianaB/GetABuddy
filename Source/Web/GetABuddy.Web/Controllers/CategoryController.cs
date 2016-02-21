namespace GetABuddy.Web.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    using Services.Data;
    using ViewModels.Category;

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
            var viewModel = this.Mapper.Map<IEnumerable<CategoryViewModel>>(categories);

            return this.View(viewModel);
        }

        public ActionResult ById(string id)
        {
            var category = this.categories.GetById(id);
            var viewModel = this.Mapper.Map<CategoryDetailsViewModel>(category);

            return this.View(viewModel);
        }
    }
}
