using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dislinkt.Posts
{
    public class AddCommentData
    {
        /// <summary>
        /// Publisher id
        /// </summary>
        public Guid PublisherId { get; set; }
        /// <summary>
        /// text
        /// </summary>
        public String Text { get; set; }
        /// <summary>
        /// text
        /// </summary>
        public Guid PostId { get; set; }
    }
}
