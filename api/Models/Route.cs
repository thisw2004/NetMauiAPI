using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Route
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Distance { get; set; }
        public string? StartPoint { get; set; }
        public string? EndPoint { get; set; }
    }
}