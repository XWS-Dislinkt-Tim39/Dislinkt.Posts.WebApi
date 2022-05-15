using System;

namespace Dislinkt.Posts.Domain.Posts
{
    public class Comment
    {
        public Guid Id { get; }
        public Guid UserId { get; }
        public string Text { get; }
        public DateTime DateTimeOfPublishing { get; }
        public Comment(Guid id, Guid userId, string text, DateTime dateTimeOfPublishing)
        {
            Id = id;
            UserId = userId;
            Text = text;
            DateTimeOfPublishing = dateTimeOfPublishing;
        }
    }
}
