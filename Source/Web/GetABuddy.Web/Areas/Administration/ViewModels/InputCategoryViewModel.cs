namespace GetABuddy.Web.Areas.Administration.ViewModels
{
    using Data.Models;
    using Infrastructure.Mapping;

    public class InputCategoryViewModel : IMapFrom<Category>
    {
        public string Name { get; set; }
    }
}
