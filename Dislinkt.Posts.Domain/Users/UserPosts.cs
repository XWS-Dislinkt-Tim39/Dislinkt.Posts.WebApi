using Dislinkt.Posts.Domain.Posts;
using System;

namespace Dislinkt.Posts.Domain.Users
{
    public class UserPosts
    {
        public Guid Id { get; }
        public Guid UserId { get; }
        public Post[] Posts { get; }

        public UserPosts(Guid id, Guid userId, Post[] posts)
        {
            Id = id;
            UserId = userId;
            Posts = posts;
        }
    }
}
