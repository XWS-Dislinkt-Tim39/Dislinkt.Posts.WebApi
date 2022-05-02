using MediatR;

namespace Dislinkt.Posts.Application.Posts.NewPost
{
    public class NewPostCommand : IRequest<bool>
    {
        public NewPostCommand(PostData postData)
        {
            this.Request = postData;
        }
        public PostData Request;
    }
}
