using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using api.Data;
using api.Mappers;
using api.Dtos.Stepgoal;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/stepgoals")] //user or users? all users bc otherwise you need to specify an id 
    [ApiController]
    public class StepgoalController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public StepgoalController(ApplicationDBContext context){

            _context = context;
        }

        //get all users
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var stepgoals = await _context.Stepgoal.ToListAsync();
            var stepgoaldto = stepgoals.Select(s => s.ToStepgoalDTO());

            return Ok(stepgoals);
        }

        //get 1 user
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var stepgoal = await _context.Stepgoal.FindAsync(id);

            if(stepgoal == null){
                return NotFound();
            }

            return Ok(stepgoal.ToStepgoalDTO());

            //return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStepgoalRequestDto stepgoalDTO){
            var stepgoalModel = stepgoalDTO.ToStepgoalFromCreateDTO();
            await _context.Stepgoal.AddAsync(stepgoalModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new {id = stepgoalModel.ID},stepgoalModel.ToStepgoalDTO());
        }


        [HttpPut]
        [Route("{id}")]

        public async Task<IActionResult> Update([FromRoute] int id,[FromBody] UpdateStepgoalRequestDto updateDto){
            var stepgoalModel = await _context.Stepgoal.FirstOrDefaultAsync(x => x.ID == id);

            if(stepgoalModel == null){
                return NotFound();
            }

            stepgoalModel.Goal = updateDto.Goal;
           

           await  _context.SaveChangesAsync();

            return Ok(stepgoalModel.ToStepgoalDTO());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id){
            var stepgoalModel = await _context.Stepgoal.FirstOrDefaultAsync(x => x.ID == id);

            if(stepgoalModel == null){
                return NotFound();
            }

            _context.Stepgoal.Remove(stepgoalModel);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}