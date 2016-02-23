namespace GetABuddy.Web.Areas.Administration.ViewModels
{
    using System.Collections.Generic;

    public class EditCategoryViewModel
    {
        public ICollection<CategoryViewModel> Categories { get; set; }
    }
}