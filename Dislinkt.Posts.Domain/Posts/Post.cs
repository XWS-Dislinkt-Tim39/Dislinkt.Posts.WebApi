using System;
using Dislinkt.Posts.Domain.Comments;

namespace Dislinkt.Posts.Domain.Posts
{
    public class Post
    {
        public Guid Id { get; }
        public string Text { get; }
        public byte[] Image { get; }
        public string Link { get; }
        public DateTime DateTimeOfPublishing { get; }
        public Guid[] Likes { get; }
        public Guid[] Dislikes { get; }
        public Comment[] Comments { get; }
        public Post(Guid id, string text, DateTime dateTime, Guid[] likes, Guid[] dislikes, Comment[] comments)
        {
            Id = id;
            Text = text;
            Image = image;
            Link = link;
            DateTimeOfPublishing = dateTime;
            Likes = likes;
            Dislikes = dislikes;
            Comments = comments;
        }
    }
}
