using MediatR;

namespace Dislinkt.Posts.Application.Posts.UnlikePost.Commands
{
    public class UnlikePostCommand : IRequest<bool>
    {
        public UnlikePostCommand(UnlikePostData unlikePostData)
        {
            this.Request = unlikePostData;
        }
        public UnlikePostData Request;
    }
}
