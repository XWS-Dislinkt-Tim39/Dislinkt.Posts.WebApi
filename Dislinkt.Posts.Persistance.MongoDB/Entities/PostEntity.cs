using Dislinkt.Posts.Domain.Posts;
using System;
using System.Linq;

namespace Dislinkt.Posts.Persistance.MongoDB.Entities
{
    public class PostEntity : BaseEntity
    {
        public string Text { get; set; }
        public byte[] Image { get; set; }
        public string Link { get; set; }
        public DateTime DateTimeOfPublishing { get; set; }
        public Guid[] UsersLiked { get; set; }
        public CommentEntity[] Comments { get; set; }
        public Post ToPost()
            => new Post(this.Id, this.Text, this.Image, this.Link, this.DateTimeOfPublishing, this.UsersLiked, this.Comments?.Select(a => a.ToComment())?.ToArray());
        public static PostEntity ToPostEntity(Post post)
        {
            return new PostEntity
            {
                Id = post.Id,
                Text = post.Text,
                Image = post.Image,
                Link = post.Link,
                DateTimeOfPublishing = post.DateTimeOfPublishing,
                UsersLiked = post.UsersLiked,
                Comments = post.Comments.Select(c => CommentEntity.ToCommentEntity(c)).ToArray()
            }; 
        }
    }
}
