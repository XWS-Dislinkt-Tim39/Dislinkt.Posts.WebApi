using Dislinkt.Posts.Core.Repositories;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Dislinkt.Posts.Application.Posts.UnlikePost.Commands
{
    public class UnlikePostHandler : IRequestHandler<UnlikePostCommand, bool>
    {
        private readonly IPostRepository _postRepository;
        public UnlikePostHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        public async Task<bool> Handle(UnlikePostCommand request, CancellationToken cancellationToken)
        {
            var userPosts = await _postRepository.GetByUserId(request.Request.UserId);

            var post = userPosts.Posts.FirstOrDefault(u => u.Id == request.Request.PostId);

            var likes = post.UsersLiked.Where(u => u != request.Request.PublisherId).ToArray();

            await _postRepository.LikePostAsync(request.Request.UserId, request.Request.PostId, likes);

            return true;
        }
    }
}
