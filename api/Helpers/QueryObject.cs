using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Helpers
{
    public class QueryObject
    {
        //which filters do we need for blog?
        //blog

        public string? Title { get; set; } = null;
        public string? Author { get; set; } = null;
        public DateTime? Date { get; set; } = null;
    }
}