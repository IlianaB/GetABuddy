﻿namespace GetABuddy.Web.ViewModels.Home
{
    using System.Collections.Generic;

    public class IndexViewModel
    {
        public IEnumerable<EventViewModel> Events { get; set; }

        public IEnumerable<CategoryViewModel> Categories { get; set; }
    }
}
