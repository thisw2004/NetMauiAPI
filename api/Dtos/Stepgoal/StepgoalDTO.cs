using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Stepgoal
{
    public class StepgoalDTO
    {
         public int ID { get; set; }

        [Required]
        public int Goal { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public int Progress { get; set; }

        public bool Achieved { get; set; }
    }
}