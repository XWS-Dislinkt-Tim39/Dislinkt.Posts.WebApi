using Dislinkt.Posts.Domain.Posts;
using Dislinkt.Posts.Persistance.MongoDB.Attributes;
using System;

namespace Dislinkt.Posts.Persistance.MongoDB.Entities
{
    [CollectionName("Posts")]
    public class PostEntity : BaseEntity
    {
        public Guid UserId { get; set; }
        public string Text { get; set; }
        public DateTime DateTimeOfPublishing { get; set; }
        public Post ToPost()
            => new Post(this.Id, this.UserId, this.Text, this.DateTimeOfPublishing);
        public static PostEntity ToPostEntity(Post post)
        {
            return new PostEntity
            {
                Id = post.Id,
                UserId = post.UserId,
                Text = post.Text,
                DateTimeOfPublishing = post.DateTimeOfPublishing
            }; 
        }
    }
}
