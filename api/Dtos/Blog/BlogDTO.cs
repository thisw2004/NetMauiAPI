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

        //for now, not sure about if the dates need to be required as we set todays date as default for some dates
        //TODO: set todays date as default,perhaps we dont need this date bc we have created at ofc
        public DateTime Date { get; set; }
        //TODO: set todays date as default for created at date
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}