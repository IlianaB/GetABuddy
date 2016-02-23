namespace GetABuddy.Web.ViewModels.Event
{
    using System;

    using Data.Models;
    using Infrastructure.Mapping;

    public class MyEventsViewModel : IMapFrom<Event>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime Time { get; set; }

        public int NumberOfParticipants { get; set; }
    }
}