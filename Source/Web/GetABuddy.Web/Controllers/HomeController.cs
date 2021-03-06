﻿namespace GetABuddy.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Infrastructure.Mapping;
    using Services.Data;
    using ViewModels.Home;

    public class HomeController : BaseController
    {
        private readonly IEventsService events;
        private readonly ICategoriesService categories;

        public HomeController(
            IEventsService events,
            ICategoriesService categories)
        {
            this.events = events;
            this.categories = categories;
        }

        public ActionResult Index()
        {
            var events = this.events.GetNewest(3).To<EventViewModel>().ToList();
            var categories =
                this.Cache.Get(
                    "categories",
                    () => this.categories.GetAll().To<CategoryViewModel>().ToList(),
                    30 * 60);

            var viewModel = new IndexViewModel
            {
                Events = events,
                Categories = categories
            };

            return this.View(viewModel);
        }
    }
}
