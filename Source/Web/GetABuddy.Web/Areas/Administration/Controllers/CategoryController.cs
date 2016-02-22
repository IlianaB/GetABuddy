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
        public ActionResult Edit(string id, string name)
        {
            var category = this.categories.Update(id, name);
            var categories = this.Mapper.Map<CategoryViewModel>(category);

            return this.PartialView("_Category", category);
        }

        [HttpPost]
        public JsonResult Delete(string id)
        {
            this.categories.Delete(id);

            return new JsonResult();
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