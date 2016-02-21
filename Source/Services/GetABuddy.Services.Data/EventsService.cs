namespace GetABuddy.Services.Data
{
    using System;
    using System.Linq;

    using GetABuddy.Data.Common;
    using GetABuddy.Data.Models;
    using Web;

    public class EventsService : IEventsService
    {
        private readonly IDbRepository<Event, int> events;
        private readonly IDbRepository<City, int> cities;
        private readonly IDbRepository<Category, int> categories;
        private readonly IDbRepository<ApplicationUser, string> users;
        private readonly IIdentifierProvider identifierProvider;

        public EventsService(
            IDbRepository<Event, int> events,
            IDbRepository<City, int> cities,
            IDbRepository<Category, int> categories,
            IDbRepository<ApplicationUser, string> users,
            IIdentifierProvider identifierProvider)
        {
            this.events = events;
            this.cities = cities;
            this.categories = categories;
            this.users = users;
            this.identifierProvider = identifierProvider;
        }

        public IQueryable<Event> GetAll()
        {
            return this.events.All();
        }

        public Event GetById(string id)
        {
            int intId = 1;
            int.TryParse(id, out intId);
            var eventById = this.events.GetById(intId);

            return eventById;
        }

        public IQueryable<Event> GetNewest(int count)
        {
            return this.events.All().OrderByDescending(x => x.CreatedOn).Take(count);
        }

        public void AddComment(Event eventToModify, Comment comment)
        {
            eventToModify.Comments.Add(comment);
            this.events.Save();
        }

        public void AddParticipant(string id, ApplicationUser user)
        {
            var eventById = this.GetById(id);
            eventById.Participants.Add(user);
            this.events.Save();
        }

        public Event Create(string name, string description, DateTime time, int numberOfParticipants, int cityId, int categoryId, string authorId)
        {
            var newEvent = new Event()
            {
                Name = name,
                Description = description,
                Time = time,
                NumberOfParticipants = numberOfParticipants,
                CityId = cityId,
                CategoryId = categoryId,
                CreatorId = authorId
            };

            var ci = cityId == 0 ? 2 : cityId;
            var city = this.cities.GetById(ci);
            city.Events.Add(newEvent);

            var category = this.categories.GetById(categoryId);
            category.Events.Add(newEvent);

            var user = this.users.GetById(authorId);
            user.Events.Add(newEvent);

            this.events.Add(newEvent);
            this.events.Save();

            return newEvent;
        }
    }
}
