using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Stepgoal;
using api.Models;

namespace api.Mappers
{
    public static class StepgoalMappers
    {
        public static StepgoalDTO ToStepgoalDTO(this Stepgoal stepgoalModel){
            return new StepgoalDTO{
                //set here all data you want to be displayed.
                ID = stepgoalModel.ID,
                Goal = stepgoalModel.Goal,
                Date = stepgoalModel.Date,
                Progress = stepgoalModel.Progress,
                Achieved = stepgoalModel.Achieved
                
            };
        }
    }
}