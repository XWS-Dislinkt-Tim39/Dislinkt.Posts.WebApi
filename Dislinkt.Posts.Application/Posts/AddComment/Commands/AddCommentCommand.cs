using MediatR;

namespace Dislinkt.Posts.Application.Posts.Commands.AddComment
{
    public class AddCommentCommand : IRequest<bool>
    {
        public AddCommentCommand(CommentData commentData)
        {
            this.Request = commentData;
        }
        public CommentData Request;
    }
}
