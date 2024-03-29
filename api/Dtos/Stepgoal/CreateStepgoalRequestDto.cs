using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Stepgoal
{
    public class CreateStepgoalRequestDto
    {
        public int Goal { get; set; }
        //rest of the properties need to be added by logic,not by user when creating stepgoal
    }
}