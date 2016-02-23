namespace GetABuddy.Services.Data
{
    using System;
    using System.Linq;

    using GetABuddy.Data.Models;

    public interface IEventsService
    {
        IQueryable<Event> GetAll();

        IQueryable<Event> GetNewest(int count);

        IQueryable<Event> GetByAuthorId(string id);

        IQueryable<Event> FindAllByName(string word);

        Event GetById(string id);

        void AddComment(Event eventToModify, Comment comment);

        void AddParticipant(string id, ApplicationUser user);

        Event Create(string name, string description, DateTime time, int numberOfParticipants, int cityId, int categoryId, string authorId);

        Event Update(string id, string name, string description, DateTime time, int numberOfParticipants);

        void Delete(string id);
    }
}
