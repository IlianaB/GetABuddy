namespace GetABuddy.Web.ViewModels.EventDetails
{
    using System;

    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;

    public class CommentViewModel : IMapFrom<Comment>, IHaveCustomMappings
    {
        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Author { get; set; }

        public string AuthorId { get; set; }

        public string Event { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Comment, CommentViewModel>()
                .ForMember(x => x.Author, opt => opt.MapFrom(x => x.Author.UserName));

            configuration.CreateMap<Comment, CommentViewModel>()
                .ForMember(x => x.Event, opt => opt.MapFrom(x => x.Event.Name));
        }
    }
}
