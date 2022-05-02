using Dislinkt.Posts.Core.Repositories;
using MediatR;
using System;
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
            await _postRepository.AddAsync(new Domain.Posts.Post(Guid.NewGuid(), request.Request.UserId, request.Request.Text, request.Request.DateTimeOfPublishing));

            return true;
        }
    }
}
