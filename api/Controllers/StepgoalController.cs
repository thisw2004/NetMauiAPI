using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using api.Data;
using api.Mappers;

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
        public IActionResult GetAll()
        {
            var stepgoals = _context.Stepgoal.ToList()
            .Select(s => s.ToStepgoalDTO());

            return Ok(stepgoals);
        }

        //get 1 user
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var stepgoal = _context.Stepgoal.Find(id);

            if(stepgoal == null){
                return NotFound();
            }

            return Ok(stepgoal.ToStepgoalDTO());

            //return Ok(users);
        }
    }
}