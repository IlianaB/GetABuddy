﻿namespace GetABuddy.Services.Data
{
    using System.Linq;

    using GetABuddy.Data.Common;
    using GetABuddy.Data.Models;

    public class CategoriesService : ICategoriesService
    {
        private readonly IDbRepository<Category, int> categories;

        public CategoriesService(IDbRepository<Category, int> categories)
        {
            this.categories = categories;
        }

        public Category EnsureCategory(string name)
        {
            var category = this.categories.All().FirstOrDefault(x => x.Name == name);
            if (category != null)
            {
                return category;
            }

            category = new Category { Name = name };
            this.categories.Add(category);
            this.categories.Save();
            return category;
        }

        public IQueryable<Category> GetAll()
        {
            return this.categories.All().OrderBy(x => x.Name);
        }
    }
}
