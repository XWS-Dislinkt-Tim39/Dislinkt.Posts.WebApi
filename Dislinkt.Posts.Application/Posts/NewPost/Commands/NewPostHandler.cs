using Dislinkt.Posts.Core.Repositories;
using Dislinkt.Posts.Domain.Comments;
using Dislinkt.Posts.Domain.Posts;
using MediatR;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Dislinkt.Posts.Application.Posts.NewPost
{
    public class NewPostHandler : IRequestHandler<NewPostCommand, Post>
    {
        private readonly IPostRepository _postRepository;
        public NewPostHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        public async Task<Post> Handle(NewPostCommand request, CancellationToken cancellationToken)
        {
            var userPosts = await _postRepository.GetByUserId(request.Request.UserId);
            var newPost = new Post(Guid.NewGuid(), request.Request.Text, "", request.Request.DateTimeOfPublishing, Array.Empty<Guid>(), Array.Empty<Guid>(), Array.Empty<Comment>());

            if (userPosts == null)
            {
                await _postRepository.CreateAsync(new Domain.Users.UserPosts(Guid.NewGuid(), request.Request.UserId,
                    new[] { newPost}));

                return newPost;
            }

            var posts = userPosts.Posts.Append(newPost);
            await _postRepository.UpdateAsync(userPosts.Id, posts.ToArray());

            return newPost;
        }
    }
}
