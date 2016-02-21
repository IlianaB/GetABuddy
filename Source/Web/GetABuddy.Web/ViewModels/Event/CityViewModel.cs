namespace GetABuddy.Web.ViewModels.Event
{
    using Data.Models;
    using Infrastructure.Mapping;

    public class CityViewModel : IMapFrom<City>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}