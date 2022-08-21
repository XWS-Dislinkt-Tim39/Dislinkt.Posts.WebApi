using Dislinkt.Posts.Domain.Posts;
using MediatR;

namespace Dislinkt.Posts.Application.Posts.NewPost
{
    public class NewPostCommand : IRequest<Post>
    {
        public NewPostCommand(PostData postData)
        {
            this.Request = postData;
        }
        public PostData Request;
    }
}
