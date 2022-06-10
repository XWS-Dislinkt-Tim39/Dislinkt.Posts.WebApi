using Dislinkt.Posts.Core.Repositories;
using Dislinkt.Posts.Domain.Posts;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Dislinkt.Posts.Application.Posts.ShowPosts.Commands
{
    public class ShowPostsHandler : IRequestHandler<ShowPostsCommand, IReadOnlyList<Post>>
    {
        private readonly IPostRepository _postRepository;
        public ShowPostsHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        public async Task<IReadOnlyList<Post>> Handle(ShowPostsCommand request, CancellationToken cancellationToken)
        {

            var userPosts = await _postRepository.GetByUserId(request.UserId);

            if (userPosts == null)
            {
                return null;
            }

            return userPosts.Posts; ;
        }
    }
}
