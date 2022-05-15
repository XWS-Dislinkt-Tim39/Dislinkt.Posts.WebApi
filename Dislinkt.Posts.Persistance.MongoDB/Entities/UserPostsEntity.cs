using Dislinkt.Posts.Domain.Users;
using Dislinkt.Posts.Persistance.MongoDB.Attributes;
using System;
using System.Linq;

namespace Dislinkt.Posts.Persistance.MongoDB.Entities
{
    [CollectionName("UserPosts")]
    public class UserPostsEntity : BaseEntity
    {
        public Guid UserId { get; set; }
        public PostEntity[] Posts { get; set; }

        public UserPosts ToUserPosts()
            => new UserPosts(this.Id, this.UserId, this.Posts?.Select(s => s.ToPost())?.ToArray());

        public static UserPostsEntity ToUserPostsEntity(UserPosts userPosts)
        {
            return new UserPostsEntity
            {
                Id = userPosts.Id,
                UserId = userPosts.UserId,
                Posts = userPosts.Posts?.Select(s => PostEntity.ToPostEntity(s))?.ToArray()
            };
        }
    }
}
