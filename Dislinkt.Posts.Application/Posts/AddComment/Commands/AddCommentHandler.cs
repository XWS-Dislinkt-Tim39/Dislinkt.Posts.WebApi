using Dislinkt.Posts.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace Dislinkt.Posts.Application.Posts.Commands.AddComment
{
    public class AddCommentHandler : IRequestHandler<AddCommentCommand, bool>
    {
        private readonly IPostRepository _postRepository;
        public AddCommentHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        public async Task<bool> Handle(AddCommentCommand request, CancellationToken cancellationToken)
        {
            var userPosts = await _postRepository.GetByUserId(request.Request.UserId);

            var post = userPosts.Posts.FirstOrDefault(u => u.Id == request.Request.PostId);

            var comments = post.Comments.Append(new Domain.Posts.Comment(System.Guid.NewGuid(), request.Request.PublisherId, request.Request.Text, request.Request.DateTimeOfPublishing));

            await _postRepository.AddCommentAsync(request.Request.UserId, request.Request.PostId, comments.ToArray());

            return true;
        }
    }
}
