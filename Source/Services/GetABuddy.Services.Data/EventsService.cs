﻿namespace GetABuddy.Services.Data
{
    using System.Linq;

    using GetABuddy.Data.Common;
    using GetABuddy.Data.Models;
    using Web;

    public class EventsService : IEventsService
    {
        private readonly IDbRepository<Event, int> events;
        private readonly IIdentifierProvider identifierProvider;

        public EventsService(IDbRepository<Event, int> events, IIdentifierProvider identifierProvider)
        {
            this.events = events;
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
    }
}
