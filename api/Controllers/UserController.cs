using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.User;
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
        
        [HttpPost]
        public IActionResult Create([FromBody] CreateUserRequestDto userDTO){
            var userModel = userDTO.ToUserFromCreateDTO();
            _context.User.Add(userModel);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new {id = userModel.ID},userModel.ToUserDTO());
        }

        [HttpPut]
        [Route("{id}")]

        public IActionResult Update([FromRoute] int id,[FromBody] UpdateUserRequestDto updateDto){
            var userModel = _context.User.FirstOrDefault(x => x.ID == id);

            if(userModel == null){
                return NotFound();
            }

            userModel.Name = updateDto.Name;
            userModel.Email = updateDto.Email;
            userModel.Password = updateDto.Password;

            _context.SaveChanges();

            return Ok(userModel.ToUserDTO());
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id){
            var userModel = _context.User.FirstOrDefault(x => x.ID == id);

            if(userModel == null){
                return NotFound();
            }

            _context.User.Remove(userModel);

            _context.SaveChanges();

            return NoContent();
        }
    }
}