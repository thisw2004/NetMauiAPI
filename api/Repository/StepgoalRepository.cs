using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Interfaces;
using api.Data;
using api.Models;
using Microsoft.EntityFrameworkCore;
using api.Dtos.Stepgoal;

namespace api.Repository
{
    public class StepgoalRepository : IStepgoalRepository
    {
        private readonly ApplicationDBContext _context;

        public StepgoalRepository(ApplicationDBContext context){
            _context = context;
        }

        public async Task<Stepgoal> CreateAsync(Stepgoal StepgoalModel)
        {
            await _context.Stepgoal.AddAsync(StepgoalModel);
            await _context.SaveChangesAsync();
            return StepgoalModel;
        }

        public async Task<Stepgoal?> DeleteAsync(int id)
        {
            var stepgoalModel = await _context.Stepgoal.FirstOrDefaultAsync(x => x.ID == id);

            if(stepgoalModel == null){
                return null;
            }

            _context.Stepgoal.Remove(stepgoalModel);
            await _context.SaveChangesAsync();
            return stepgoalModel;
        }

        public async Task<List<Stepgoal>> GetAllAsync()
        {
           return await _context.Stepgoal.ToListAsync();
        }

        public async Task<Stepgoal?> GetByIdAsync(int id)
        {
            return await _context.Stepgoal.FindAsync(id);
        }

        public async Task<Stepgoal?> UpdateAsync(int id, UpdateStepgoalRequestDto StepgoalDto)
        {
            var existingStepgoal = await _context.Stepgoal.FirstOrDefaultAsync(x => x.ID == id);

            if(existingStepgoal == null){
                return null;
            }

            existingStepgoal.Goal = StepgoalDto.Goal;
            // existingStepgoal.Achieved = StepgoalDTO.Achieved;

            //hier achieved enz?

            await _context.SaveChangesAsync();

            return existingStepgoal;
        }
    }
}