namespace GetABuddy.Services.Data
{
    using GetABuddy.Data.Models;

    public interface ICommentsService
    {
        Comment Create(string content, int eventId, string authorId);
    }
}
