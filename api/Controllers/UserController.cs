using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.User;
using api.Interfaces;
using api.Mappers;
using api.Migrations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace api.Controllers
{
    [Route("api/users")] //user or users? all users bc otherwise you need to specify an id 
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IUserRepository _userRepo;

        public UserController(ApplicationDBContext context,IUserRepository userRepo){

            _userRepo = userRepo;
            _context = context;
        }
        //get all users
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userRepo.GetAllAsync();
            var userdto = users.Select(s => s.ToUserDTO());

            return Ok(users);
        }

        //get 1 user
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var user =await _context.User.FindAsync(id);

            if(user == null){
                return NotFound();
            }

            return Ok(user.ToUserDTO());

            //return Ok(users);
        }
        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserRequestDto userDTO){
            var userModel = userDTO.ToUserFromCreateDTO();
            await _context.User.AddAsync(userModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new {id = userModel.ID},userModel.ToUserDTO());
        }

        [HttpPut]
        [Route("{id}")]

        public async Task<IActionResult> Update([FromRoute] int id,[FromBody] UpdateUserRequestDto updateDto){
            var userModel = await _context.User.FirstOrDefaultAsync(x => x.ID == id);

            if(userModel == null){
                return NotFound();
            }

            userModel.Name = updateDto.Name;
            userModel.Email = updateDto.Email;
            userModel.Password = updateDto.Password;

             await _context.SaveChangesAsync();

            return Ok(userModel.ToUserDTO());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id){
            var userModel = await _context.User.FirstOrDefaultAsync(x => x.ID == id);

            if(userModel == null){
                return NotFound();
            }

            _context.User.Remove(userModel);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}