﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dislinkt.Posts.Application.Posts.PostLike.Commands
{
    public class RemoveLikePostCommand : IRequest<bool>
    {
        public RemoveLikePostCommand(Guid userId, Guid postId)
        {
            this.UserId = userId;
            this.PostId = postId;
        }
        public Guid UserId;
        public Guid PostId;
    }
}
