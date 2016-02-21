namespace GetABuddy.Web.ViewModels.Event
{
    using System;
    using System.ComponentModel;

    using Data.Models;
    using Infrastructure.Mapping;

    public class InputEventViewModel : IMapFrom<Event>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime Time { get; set; }

        [DisplayName("Category")]
        public int CategoryId { get; set; }

        [DisplayName("City")]
        public int CityId { get; set; }

        [DisplayName("Number of participants")]
        public int NumberOfParticipants { get; set; }
    }
}