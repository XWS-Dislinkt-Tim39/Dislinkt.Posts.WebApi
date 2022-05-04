using Dislinkt.Posts.Domain.Posts;
using MediatR;
using System;
using System.Collections.Generic;

namespace Dislinkt.Posts.Application.Posts.ShowPosts.Commands
{
    public class ShowPostsCommand : IRequest<IReadOnlyList<Post>>
    {
        public ShowPostsCommand(Guid userId)
        {
            this.UserId = userId;
        }
        public Guid UserId;
    }
}
