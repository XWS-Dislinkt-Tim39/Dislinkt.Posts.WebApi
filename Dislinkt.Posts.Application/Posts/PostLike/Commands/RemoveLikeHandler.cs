using Dislinkt.Posts.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dislinkt.Posts.Application.Posts.PostLike.Commands
{
    public class RemoveLikePostHandler : IRequestHandler<RemoveLikePostCommand, bool>
    {
        private readonly IPostRepository _postRepository;
        public RemoveLikePostHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        public async Task<bool> Handle(RemoveLikePostCommand request, CancellationToken cancellationToken)
        {
            await _postRepository.RemoveLikeFromUserPostAsync(request.UserId, request.PostId);

            return true;
        }
    }
}
