namespace GetABuddy.Services.Data
{
    using System.Linq;

    using GetABuddy.Data.Models;

    public interface ICategoriesService
    {
        IQueryable<Category> GetAll();

        IQueryable<Category> GetNewest();

        Category GetById(string id);

        Category EnsureCategory(string name);

        Category Update(string id, string name);

        Category Create(string id);

        void Delete(string id);
    }
}
