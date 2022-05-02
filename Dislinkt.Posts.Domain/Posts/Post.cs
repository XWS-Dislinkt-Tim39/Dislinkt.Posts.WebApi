using System;

namespace Dislinkt.Posts.Domain.Posts
{
    public class Post
    {
        public Guid Id { get; }
        public Guid UserId { get; }
        public string Text { get; }
        public DateTime DateTimeOfPublishing { get; }
        public Post(Guid id, Guid userId, string text, DateTime dateTime)
        {
            Id = id;
            UserId = userId;
            Text = text;
            DateTimeOfPublishing = dateTime;
        }
    }
}
