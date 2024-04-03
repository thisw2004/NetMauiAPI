using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Route
{
    public class UpdateRouteRequestDto
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public int Distance { get; set; }
        [Required]
        public string? StartPoint { get; set; }
        [Required]
        public string? EndPoint { get; set; }
    }
}