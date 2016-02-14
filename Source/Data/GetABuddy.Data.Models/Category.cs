namespace GetABuddy.Data.Models
{
    using System.Collections.Generic;

    using Common.Models;

    public class Category : BaseModel<int>
    {
        private ICollection<Event> events;

        public Category()
        {
            this.events = new HashSet<Event>();
        }

        public string Name { get; set; }

        public virtual ICollection<Event> Events
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
