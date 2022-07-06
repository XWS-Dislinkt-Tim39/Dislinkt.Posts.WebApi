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
    public class AddDislikeHandler : IRequestHandler<AddDislikeCommand, bool>
    {
        private readonly IPostRepository _postRepository;
        public AddDislikeHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        public async Task<bool> Handle(AddDislikeCommand request, CancellationToken cancellationToken)
        {
            await _postRepository.AddDislikeToUserPostAsync(request.UserId, request.PostId);

            return true;
        }
    }
}
