namespace GetABuddy.Web.Areas.Users.ViewModels
{
    using System;
    using System.Collections.Generic;

    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;

    public class UserInfoViewModel : IMapFrom<ApplicationUser>, IHaveCustomMappings
    {
        public string DisplayName { get; set; }

        public ICollection<EventViewModel> Events { get; set; }

        public int Years { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<ApplicationUser, UserInfoViewModel>()
                .ForMember(x => x.Years, opt => opt.MapFrom(x => DateTime.Now.Year - x.DateOfBirth.Year));
        }
    }
}