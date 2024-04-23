using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Stepgoal
{
    public class CreateStepgoalRequestDto
    {
        public int ID { get; set; }

        [Required]
        public int Goal { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public int Progress { get; set; }

        public bool Achieved { get; set; }
        //rest of the properties need to be added by logic,not by user when creating stepgoal
    }
}