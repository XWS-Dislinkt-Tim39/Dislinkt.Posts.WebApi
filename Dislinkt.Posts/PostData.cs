using Dislinkt.Posts.Domain.Comments;
using System;

namespace Dislinkt.Posts
{
    public class PostData
    {
        /// <summary>
        /// User Id
        /// </summary>
        public Guid UserId { get; set; }
        /// <summary>
        /// Text
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Image
        /// </summary>
        public string Image { get; set; }
        /// <summary>
        /// Link
        /// </summary>
        public string Link { get; set; }
        /// <summary>
        /// Date time of publishing+
        /// </summary>
        public DateTime DateTimeOfPublishing { get; set; }
      
       
    }
}
