using Dislinkt.Posts.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dislinkt.Posts.Application.Posts.PostDislike.Commands
{
    public class RemoveDislikeHandler : IRequestHandler<RemoveDislikeCommand, bool>
    {
        private readonly IPostRepository _postRepository;
        public RemoveDislikeHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        public async Task<bool> Handle(RemoveDislikeCommand request, CancellationToken cancellationToken)
        {
            await _postRepository.RemoveDislikeFromUserPostAsync(request.UserId, request.PostId);

            return true;
        }
    }
}
