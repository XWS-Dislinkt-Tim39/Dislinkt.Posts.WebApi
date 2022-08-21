using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dislinkt.Posts.Domain.Posts
{
    public class FileUpload
    {
        public IFormFile File { get; set; }
        public string Post { get; set; }
    }
}
