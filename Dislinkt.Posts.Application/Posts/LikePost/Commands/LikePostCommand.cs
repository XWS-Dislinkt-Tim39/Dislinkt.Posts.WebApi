using MediatR;

namespace Dislinkt.Posts.Application.Posts.LikePost.Commands
{
    public class LikePostCommand : IRequest<bool>
    {
        public LikePostCommand(LikePostData likePostData)
        {
            this.Request = likePostData;
        }
        public LikePostData Request;
    }
}
