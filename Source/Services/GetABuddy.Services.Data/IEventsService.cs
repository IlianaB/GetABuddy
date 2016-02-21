namespace GetABuddy.Services.Data
{
    using System.Linq;

    using GetABuddy.Data.Models;

    public interface IEventsService
    {
        IQueryable<Event> GetAll();

        IQueryable<Event> GetNewest(int count);

        Event GetById(string id);

        void AddComment(Event eventToModify, Comment comment);
    }
}
