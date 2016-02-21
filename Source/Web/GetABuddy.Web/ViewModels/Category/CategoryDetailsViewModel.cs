namespace GetABuddy.Web.ViewModels.Category
{
    using System.Collections.Generic;

    using Data.Models;
    using Infrastructure.Mapping;

    public class CategoryDetailsViewModel : IMapFrom<Category>
    {
        public string Name { get; set; }

        public ICollection<EventDetailsViewModel> Events { get; set; }
    }
}