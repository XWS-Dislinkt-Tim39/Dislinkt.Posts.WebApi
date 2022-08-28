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
        /// Date time of publishing+
        /// </summary>
        /// 
        public DateTime DateTimeOfPublishing { get; set; }

        public string[] followersId { get; set; }


    }
}
