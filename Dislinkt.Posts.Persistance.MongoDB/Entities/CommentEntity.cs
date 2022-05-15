using Dislinkt.Posts.Domain.Posts;
using System;

namespace Dislinkt.Posts.Persistance.MongoDB.Entities
{
    public class CommentEntity : BaseEntity
    {
        public Guid UserId { get; set; }
        public string Text { get; set; }
        public DateTime DateTimeOfPublishing { get; set; }
        public Comment ToComment()
            => new Comment(this.Id, this.UserId, this.Text, this.DateTimeOfPublishing);
        public static CommentEntity ToCommentEntity(Comment comment)
        {
            return new CommentEntity
            {
                Id = comment.Id,
                UserId = comment.UserId,
                Text = comment.Text,
                DateTimeOfPublishing = comment.DateTimeOfPublishing
            };
        }
    }
}
