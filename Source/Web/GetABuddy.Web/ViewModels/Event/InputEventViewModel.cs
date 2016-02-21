namespace GetABuddy.Web.ViewModels.Event
{
    using System;

    using Data.Models;
    using Infrastructure.Mapping;

    public class InputEventViewModel : IMapFrom<Event>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime Time { get; set; }

        public int CategoryId { get; set; }

        public int CityId { get; set; }

        public int NumberOfParticipants { get; set; }
    }
}