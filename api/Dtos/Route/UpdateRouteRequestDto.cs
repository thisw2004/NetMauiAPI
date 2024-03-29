using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Route
{
    public class UpdateRouteRequestDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Distance { get; set; }
        public string? StartPoint { get; set; }
        public string? EndPoint { get; set; }
    }
}