namespace GetABuddy.Web.ViewModels.Category
{
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;

    public class CategoryViewModel : IMapFrom<Category>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Events { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Category, CategoryViewModel>()
                .ForMember(x => x.Events, opt => opt.MapFrom(x => x.Events.Count));
        }
    }
}
