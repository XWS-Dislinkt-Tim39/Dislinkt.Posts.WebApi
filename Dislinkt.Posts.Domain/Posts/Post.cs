using System;
using Dislinkt.Posts.Domain.Comments;

namespace Dislinkt.Posts.Domain.Posts
{
    public class Post
    {
        public Guid Id { get; }
        public string Text { get; }
        public DateTime DateTimeOfPublishing { get; }
        public Guid[] Likes { get; }
        public Guid[] Dislikes { get; }
        public Comment[] Comments { get; }
        public Post(Guid id, string text, DateTime dateTime, Guid[] likes, Guid[] dislikes, Comment[] comments)
        {
            Id = id;
            Text = text;
            DateTimeOfPublishing = dateTime;
            Likes = likes;
            Dislikes = dislikes;
            Comments = comments;
        }
    }
}
