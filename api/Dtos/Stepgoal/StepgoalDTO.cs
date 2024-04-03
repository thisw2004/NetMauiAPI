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
        //not sure if we need to put here required,fs it s required i think, but it s preferable to set todays date as default
        public DateOnly Date { get; set; }
        public int Progress { get; set; }
        [Required]
        public bool Achieved { get; set; }
    }
}