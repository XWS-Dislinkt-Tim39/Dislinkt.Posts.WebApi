using Dislinkt.Posts.Core.Repositories;
using Dislinkt.Posts.Domain.Comments;
using Dislinkt.Posts.Domain.Posts;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Dislinkt.Posts.Application.Posts.NewPost
{
    public class NewPostHandler : IRequestHandler<NewPostCommand, bool>
    {
        private readonly IPostRepository _postRepository;
        public NewPostHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        public async Task<bool> Handle(NewPostCommand request, CancellationToken cancellationToken)
        {
            var userPosts = await _postRepository.GetByUserId(request.Request.UserId);

            if(userPosts == null)
            {
                await _postRepository.CreateAsync(new Domain.Users.UserPosts(Guid.NewGuid(), request.Request.UserId,
                    new[] { new Post(Guid.NewGuid(), request.Request.Text, request.Request.DateTimeOfPublishing, Array.Empty<Guid>(), Array.Empty<Guid>(), Array.Empty<Comment>()) }));

                return true;
            }

            var posts = userPosts.Posts.Append(new Post(Guid.NewGuid(), request.Request.Text, request.Request.DateTimeOfPublishing, Array.Empty<Guid>(), Array.Empty<Guid>(), Array.Empty<Comment>()));
            await _postRepository.UpdateAsync(userPosts.Id, posts.ToArray());

            return true;
        }
    }
}
