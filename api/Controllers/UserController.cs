using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Mappers;
using api.Migrations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace api.Controllers
{
    [Route("api/users")] //user or users? all users bc otherwise you need to specify an id 
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public UserController(ApplicationDBContext context){

            _context = context;
        }

        //get all users
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _context.User.ToList()
            .Select(s => s.ToUserDTO());

            return Ok(users);
        }

        //get 1 user
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var user = _context.User.Find(id);

            if(user == null){
                return NotFound();
            }

            return Ok(user.ToUserDTO());

            //return Ok(users);
        }
    }
}