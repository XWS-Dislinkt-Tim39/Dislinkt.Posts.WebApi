using Dislinkt.Posts.Domain.Posts;
using System;

namespace Dislinkt.Posts.Persistance.MongoDB.Entities
{
    public class PostEntity : BaseEntity
    {
        public string Text { get; set; }
        public DateTime DateTimeOfPublishing { get; set; }
        public Post ToPost()
            => new Post(this.Id, this.Text, this.DateTimeOfPublishing);
        public static PostEntity ToPostEntity(Post post)
        {
            return new PostEntity
            {
                Id = post.Id,
                Text = post.Text,
                DateTimeOfPublishing = post.DateTimeOfPublishing
            }; 
        }
    }
}
