using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Motivationnotification
    {
        public string? Title { get; set; }

        public string? Content { get; set; }
        public int NumberOfSteps { get; set; }
    }
}