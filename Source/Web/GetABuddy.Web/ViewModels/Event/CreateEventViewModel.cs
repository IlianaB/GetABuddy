namespace GetABuddy.Web.ViewModels.Event
{
    using System.Collections.Generic;

    using Data.Models;

    public class CreateEventViewModel
    {
        public InputEventViewModel Event { get; set; }

        public IEnumerable<CityViewModel> Cities { get; set; }

        public IEnumerable<CategoryViewModel> Categories { get; set; }
    }
}