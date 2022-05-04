using System;

namespace Dislinkt.Posts.Domain.Posts
{
    public class Post
    {
        public Guid Id { get; }
        public string Text { get; }
        public DateTime DateTimeOfPublishing { get; }
        public Post(Guid id, string text, DateTime dateTime)
        {
            Id = id;
            Text = text;
            DateTimeOfPublishing = dateTime;
        }
    }
}
