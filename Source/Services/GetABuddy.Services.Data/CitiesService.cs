namespace GetABuddy.Services.Data
{
    using System.Linq;

    using GetABuddy.Data.Common;
    using GetABuddy.Data.Models;

    public class CitiesService : ICitiesService
    {
        private readonly IDbRepository<City, int> cities;

        public CitiesService(IDbRepository<City, int> cities)
        {
            this.cities = cities;
        }

        public IQueryable<City> GetAll()
        {
            return this.cities.All().OrderBy(x => x.Name);
        }

    }
}
