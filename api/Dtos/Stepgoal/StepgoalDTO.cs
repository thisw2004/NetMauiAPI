using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Stepgoal
{
    public class StepgoalDTO
    {
        public int ID { get; set; }
        public int Goal { get; set; }
        public DateOnly Date { get; set; }
        public int Progress { get; set; }
        public bool Achieved { get; set; }
    }
}