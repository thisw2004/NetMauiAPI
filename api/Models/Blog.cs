using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Blog
    {
        public int ID { get; set; } //pk
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? Author { get; set; }
        public DateTime Date { get; set; } = DateTime.Today;
        //do we set the default so?
        public DateTime CreatedAt { get; set; } = DateTime.Today;
        //TODO: only on update set this as default
        public DateTime UpdatedAt { get; set; } 
    }
}