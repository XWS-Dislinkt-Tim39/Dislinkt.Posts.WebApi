using System;

namespace Dislinkt.Posts
{
    public class UnlikePostData
    {
        /// <summary>
        /// Publisher id
        /// </summary>
        public Guid PublisherId { get; set; }
        /// <summary>
        /// Post id
        /// </summary>
        public Guid PostId { get; set; }
        /// <summary>
        /// User id
        /// </summary>
        public Guid UserId { get; set; }
    }
}
