using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Blog
{
    public class UpdateBlogRequestDto
    {
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? Author { get; set; }

        
    }
}