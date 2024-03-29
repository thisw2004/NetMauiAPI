using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Blog
{
    public class CreateBlogRequestDto
    {
        //wat kind of content do we need fot the user to add?
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? Author { get; set; }
    }
}