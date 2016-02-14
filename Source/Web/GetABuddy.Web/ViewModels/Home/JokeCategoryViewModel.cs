namespace GetABuddy.Web.ViewModels.Home
{
    using GetABuddy.Data.Models;
    using GetABuddy.Web.Infrastructure.Mapping;

    public class JokeCategoryViewModel : IMapFrom<JokeCategory>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
