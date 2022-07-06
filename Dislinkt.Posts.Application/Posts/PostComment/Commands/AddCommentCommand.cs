using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dislinkt.Posts.Application.Posts.PostComment.Commands
{
    public class AddCommentCommand : IRequest<bool>
    {
        public AddCommentCommand(AddCommentData commentData)
        {
            this.Request = commentData;
        }
        public AddCommentData Request;
    }
}
