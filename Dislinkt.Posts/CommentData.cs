using System;

namespace Dislinkt.Posts
{
    public class CommentData
    {
        /// <summary>
        /// User Id
        /// </summary>
        public Guid UserId { get; set; }
        /// <summary>
        /// Publisher Id
        /// </summary>
        public Guid PublisherId { get; set; }
        /// <summary>
        /// Post Id
        /// </summary>
        public Guid PostId { get; set; }
        /// <summary>
        /// Text
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Date of publishing
        /// </summary>
        public DateTime DateTimeOfPublishing { get; set; }
    }
}
