namespace GetABuddy.Services.Data
{
    using System;
    using GetABuddy.Data.Common;
    using GetABuddy.Data.Models;

    public class CommentsService : ICommentsService
    {
        private readonly IDbRepository<Comment> comments;

        public CommentsService(IDbRepository<Comment> comments)
        {
            this.comments = comments;
        }

        public Comment Create(string content, int eventId, string authorId)
        {
            var newComment = new Comment()
            {
                Content = content,
                EventId = eventId
            };

            if (authorId != string.Empty)
            {
                newComment.AuthorId = authorId;
            }

            this.comments.Add(newComment);
            this.comments.Save();

            return newComment;
        }
    }
}
