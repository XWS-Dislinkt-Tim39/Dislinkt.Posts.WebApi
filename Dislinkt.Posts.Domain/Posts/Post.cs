using System;

namespace Dislinkt.Posts.Domain.Posts
{
    public class Post
    {
        public Guid Id { get; }
        public string Text { get; }
        public byte[] Image { get; }
        public string Link { get; }
        public DateTime DateTimeOfPublishing { get; }
        public Guid[] UsersLiked { get; }
        public Comment[] Comments { get; }
        public Post(Guid id, string text, byte[] image, string link, DateTime dateTime, Guid[] usersLiked, Comment[] comments)
        {
            Id = id;
            Text = text;
            Image = image;
            Link = link;
            DateTimeOfPublishing = dateTime;
            UsersLiked = usersLiked;
            Comments = comments;
        }
    }
}
