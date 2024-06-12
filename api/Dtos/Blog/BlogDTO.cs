using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Blog
{
    public class BlogDTO
    {
        public int ID { get; set; } //pk
        //some data validation
        [Required]
        
        public string? Title { get; set; }
        [Required]
        public string? Content { get; set; }
        [Required]
        public string? Author { get; set; }

        
        public DateTime Date { get; set; }
        
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}