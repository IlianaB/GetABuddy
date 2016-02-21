namespace GetABuddy.Services.Data
{
    using System.Linq;

    using GetABuddy.Data.Models;

    public interface ICategoriesService
    {
        IQueryable<Category> GetAll();

        Category GetById(string id);

        Category EnsureCategory(string name);
    }
}
