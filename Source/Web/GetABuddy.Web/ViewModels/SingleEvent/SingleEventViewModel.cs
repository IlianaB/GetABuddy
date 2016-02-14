﻿namespace GetABuddy.Web.ViewModels.SingleEvent
{
    using System;
    using System.Collections.Generic;

    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;

    public class SingleEventViewModel : IMapFrom<Event>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime Time { get; set; }

        public string Creator { get; set; }

        public int CategoryId { get; set; }

        public string Category { get; set; }

        public string City { get; set; }

        public int NumberOfParticipants { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<ApplicationUser> Participants { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Event, SingleEventViewModel>()
                .ForMember(x => x.Creator, opt => opt.MapFrom(x => x.Creator.UserName));

            configuration.CreateMap<Event, SingleEventViewModel>()
                .ForMember(x => x.Category, opt => opt.MapFrom(x => x.Category.Name));

            configuration.CreateMap<Event, SingleEventViewModel>()
                .ForMember(x => x.City, opt => opt.MapFrom(x => x.City.Name));
        }
    }
}