using Dislinkt.Posts.Domain.Comments;
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
        Task<UserPosts> GetById(Guid id);
        Task AddLikeToUserPostAsync(Guid userId,Guid postId);
        Task RemoveLikeFromUserPostAsync(Guid userId, Guid postId);
        Task AddDislikeToUserPostAsync(Guid userId, Guid postId);
        Task RemoveDislikeFromUserPostAsync(Guid userId, Guid postId);
        Task AddCommentToUserPostAsync(Comment comment, Guid postId);

        Task CreateAsync(UserPosts userPosts);
        Task UpdateAsync(Guid id, Post[] posts);
        Task AddCommentAsync(Guid userId, Guid id, Comment[] comments);
        Task LikePostAsync(Guid publisherId, Guid postId, Guid[] userIds);
    }
}
