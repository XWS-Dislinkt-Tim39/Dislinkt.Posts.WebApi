using Dislinkt.Posts.Domain.Posts;
using Dislinkt.Posts.Domain.Users;
using System;
using System.Threading.Tasks;

namespace Dislinkt.Posts.Core.Repositories
{
    public interface IPostRepository
    {
        Task AddAsync(Post post);
        Task<UserPosts> GetByUserId(Guid userId);
        Task CreateAsync(UserPosts userPosts);
        Task UpdateAsync(Guid id, Post[] posts);
    }
}
