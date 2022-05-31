using Dislinkt.Posts.Domain.Comments;
using Dislinkt.Posts.Domain.Posts;
using System;

namespace Dislinkt.Posts.Persistance.MongoDB.Entities
{
    public class PostEntity : BaseEntity
    {
        public string Text { get; set; }
        public DateTime DateTimeOfPublishing { get; set; }
        public Guid[] Likes { get; set; }
        public Guid[] Dislikes { get; set; }
        public Comment[] Comments { get; set; }
        public Post ToPost()
            => new Post(this.Id, this.Text, this.DateTimeOfPublishing,this.Likes,this.Dislikes,this.Comments);
        public static PostEntity ToPostEntity(Post post)
        {
            return new PostEntity
            {
                Id = post.Id,
                Text = post.Text,
                DateTimeOfPublishing = post.DateTimeOfPublishing,
                Likes = post.Likes,
                Dislikes=post.Dislikes,
                Comments =post.Comments

            }; 
        }
    }
}
