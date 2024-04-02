using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Stepgoal;
using api.Models;

namespace api.Interfaces
{
    public interface IStepgoalRepository
    {
        Task<List<Stepgoal>> GetAllAsync();
        Task<Stepgoal?> GetByIdAsync(int id);
        Task<Stepgoal> CreateAsync(Stepgoal StepgoalModel);
        Task<Stepgoal?> UpdateAsync(int id,UpdateStepgoalRequestDto StepgoalDto);
        Task<Stepgoal?> DeleteAsync(int id);
    }
}