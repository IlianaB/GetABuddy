﻿namespace GetABuddy.Web.Areas.Users.ViewModels
{
    using System;

    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;

    public class EventViewModel : IMapFrom<Event>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Time { get; set; }

        public int CategoryId { get; set; }

        public string Category { get; set; }

        public string City { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Event, EventViewModel>()
                .ForMember(x => x.Category, opt => opt.MapFrom(x => x.Category.Name));

            configuration.CreateMap<Event, EventViewModel>()
                .ForMember(x => x.City, opt => opt.MapFrom(x => x.City.Name));
        }
    }
}