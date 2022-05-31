using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dislinkt.Posts.Domain.Comments
{
    public class Comment
    {
        public Guid Id { get; }
        public string Text { get; }
        public Guid UserId { get; }
        public Comment(Guid id, string text, Guid userId)
        {
            Id = id;
            Text = text;
            UserId = userId;
        }
    }
}
