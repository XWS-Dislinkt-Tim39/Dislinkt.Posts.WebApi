using Dislinkt.Posts.Core.Repositories;
using Dislinkt.Posts.Domain.Comments;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dislinkt.Posts.Application.Posts.PostComment.Commands
{
    internal class AddCommentHandler : IRequestHandler<AddCommentCommand, bool>
    {
        private readonly IPostRepository _postRepository;
        public AddCommentHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        public async Task<bool> Handle(AddCommentCommand request, CancellationToken cancellationToken)
        {

            var comment = new Comment(Guid.NewGuid(), request.Request.Text, request.Request.PublisherId);
            

           await _postRepository.AddCommentToUserPostAsync(comment, request.Request.PostId);

            return true;
        }
    }
}
