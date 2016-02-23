namespace GetABuddy.Web.Areas.Administration.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    using Services.Data;
    using ViewModels;
    using Web.Controllers;

    public class CategoryController : BaseController
    {
        private readonly ICategoriesService categories;

        public CategoryController(ICategoriesService categories)
        {
            this.categories = categories;
        }

        [HttpGet]
        public ActionResult Edit()
        {
            var categories = this.categories.GetNewest();
            var viewModel = new EditCategoryViewModel();
            viewModel.Categories = this.Mapper.Map<ICollection<CategoryViewModel>>(categories);

            return this.View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(InputCategoryViewModel input)
        {
            var category = this.categories.Update(input.Id.ToString(), input.Name);

            return this.RedirectToAction("/Edit");
        }

        [HttpPost]
        public ActionResult Delete(InputCategoryViewModel input)
        {
            this.categories.Delete(input.Id.ToString());

            return this.RedirectToAction("/Edit");
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InputCategoryViewModel input)
        {
            var newCategory = this.categories.Create(input.Name);

            return this.RedirectToAction("/Edit");
        }
    }
}