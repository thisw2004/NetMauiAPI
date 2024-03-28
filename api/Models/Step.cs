using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Step
    {
        public int ID { get; set; }
        public DateOnly Date { get; set; }
        public int NumberOfSteps { get; set; }
    }
}