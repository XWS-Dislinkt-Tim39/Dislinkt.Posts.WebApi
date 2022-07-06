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
    public class AddLikePostHandler : IRequestHandler<AddLikePostCommand, bool>
    {
        private readonly IPostRepository _postRepository;
        public AddLikePostHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        public async Task<bool> Handle(AddLikePostCommand request, CancellationToken cancellationToken)
        {
             await _postRepository.AddLikeToUserPostAsync(request.UserId,request.PostId);

            return true;
        }
    }
}
