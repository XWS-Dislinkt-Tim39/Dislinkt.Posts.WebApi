using Dislinkt.Posts.Core.Repositories;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Dislinkt.Posts.Application.Posts.LikePost.Commands
{
    public class LikePostHandler : IRequestHandler<LikePostCommand, bool>
    {
        private readonly IPostRepository _postRepository;
        public LikePostHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        public async Task<bool> Handle(LikePostCommand request, CancellationToken cancellationToken)
        {
            var userPosts = await _postRepository.GetByUserId(request.Request.UserId);

            var post = userPosts.Posts.FirstOrDefault(u => u.Id == request.Request.PostId);

            var likes = post.UsersLiked.Append(request.Request.PublisherId).ToArray();

            await _postRepository.LikePostAsync(request.Request.UserId, request.Request.PostId, likes);

            return true;
        }
    }
}
