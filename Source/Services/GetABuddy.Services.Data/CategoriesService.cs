namespace GetABuddy.Services.Data
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

        public IQueryable<Category> GetNewest()
        {
            return this.categories.All().OrderByDescending(x => x.CreatedOn);
        }

        public Category GetById(string id)
        {
            int intId = 1;
            int.TryParse(id, out intId);
            var category = this.categories.GetById(intId);

            return category;
        }

        public Category Update(string id, string name)
        {
            var category = this.GetById(id);
            category.Name = name;

            this.categories.Save();

            return category;
        }

        public Category Create(string name)
        {
            var newCategory = new Category
            {
                Name = name
            };

            this.categories.Add(newCategory);
            this.categories.Save();

            return newCategory;
        }

        public void Delete(string id)
        {
            var category = this.GetById(id);
            this.categories.Delete(category);

            this.categories.Save();
        }
    }
}
