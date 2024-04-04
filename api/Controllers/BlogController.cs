using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using api.Data;
using api.Mappers;
using api.Dtos.Blog;
using Microsoft.EntityFrameworkCore;
using api.Interfaces;
using api.Helpers;

namespace api.Controllers
{
    [Route("api/blogs")] //user or users? all users bc otherwise you need to specify an id 
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IBlogRepository _blogRepo;

        public BlogController(ApplicationDBContext context,IBlogRepository blogRepo){

            _blogRepo = blogRepo;
            _context = context;
        }

        //get all users
        [HttpGet]
        //async = execute this function tegelijk with the other instead stuk voor stuk.
        public async Task<IActionResult> GetAll([FromQuery]QueryObject query)
        {
            //data validaation
            //now not yet implemented,but fs for future use
            //not sure when validate what etc.
            //needs in all controllers
            // if(!ModelState.IsValid)
            //     return BadRequest(ModelState);
            


            var blogs = await _blogRepo.GetAllAsync();
            var blogDto = blogs.Select(s => s.ToBlogDTO());

            return Ok(blogs);
        }

        //get 1 user
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var blog = await _blogRepo.GetByIdAsync(id);

            if(blog == null){
                return NotFound();
            }

            return Ok(blog.ToBlogDTO());

            //return Ok(users);
        }
        
        // 6.
        [HttpPost]
        public  async Task<IActionResult> Create([FromBody] CreateBlogRequestDto blogDTO){
            var blogModel = blogDTO.ToBlogFromCreateDTO();
           await _blogRepo.CreateAsync(blogModel);
            return CreatedAtAction(nameof(GetById), new {id = blogModel.ID},blogModel.ToBlogDTO());
        }

        [HttpPut]
        [Route("{id}")]

        public async Task<IActionResult> Update([FromRoute] int id,[FromBody] UpdateBlogRequestDto updateDto){
            var blogModel = await _blogRepo.UpdateAsync(id,updateDto);

            if(blogModel == null){
                return NotFound();
            }

            return Ok(blogModel.ToBlogDTO());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id){
            var blogModel = await _blogRepo.DeleteAsync(id);

            if(blogModel == null){
                return NotFound();
            }

            return NoContent();
        }
    }
}