namespace GetABuddy.Services.Data
{
    using System;
    using System.Linq;

    using GetABuddy.Data.Models;

    public interface IEventsService
    {
        IQueryable<Event> GetAll();

        IQueryable<Event> GetNewest(int count);

        Event GetById(string id);

        void AddComment(Event eventToModify, Comment comment);

        void AddParticipant(string id, ApplicationUser user);

        Event Create(string name, string description, DateTime time, int numberOfParticipants, int cityId, int categoryId, string authorId);
    }
}
