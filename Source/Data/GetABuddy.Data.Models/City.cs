namespace GetABuddy.Data.Models
{
    using System.Collections.Generic;

    using Common.Models;

    public class City : BaseModel<int>
    {
        private ICollection<Event> events;

        public City()
        {
            this.events = new HashSet<Event>();
        }

        public string Name { get; set; }

        public ICollection<Event> Events
        {
            get
            {
                return this.events;
            }

            set
            {
                this.events = value;
            }
        }
    }
}
