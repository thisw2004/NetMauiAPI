using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Interfaces;
using api.Data;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class StepgoalRepository : IStepgoalRepository
    {
        private readonly ApplicationDBContext _context;

        public StepgoalRepository(ApplicationDBContext context){
            _context = context;
        }
        public Task<List<Stepgoal>> GetAllAsync()
        {
           return _context.Stepgoal.ToListAsync();
        }
    }
}