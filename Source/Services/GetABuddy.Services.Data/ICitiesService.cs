namespace GetABuddy.Services.Data
{
    using System.Linq;

    using GetABuddy.Data.Models;

    public interface ICitiesService
    {
        IQueryable<City> GetAll();
    }
}
