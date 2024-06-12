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
    [Route("api/blogs")]  
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IBlogRepository _blogRepo;

        public BlogController(ApplicationDBContext context,IBlogRepository blogRepo){

            _blogRepo = blogRepo;
            _context = context;
        }

        //get all blogs
        [HttpGet]
        
        public async Task<IActionResult> GetAll([FromQuery]QueryObject query)
        {
            
            var blogs = await _blogRepo.GetAllAsync();
            var blogDto = blogs.Select(s => s.ToBlogDTO());

            return Ok(blogs);
        }

        //get blog by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var blog = await _blogRepo.GetByIdAsync(id);

            if(blog == null){
                return NotFound();
            }

            return Ok(blog.ToBlogDTO());

        }
        
        //create blog
        [HttpPost]
        public  async Task<IActionResult> Create([FromBody] CreateBlogRequestDto blogDTO){
            var blogModel = blogDTO.ToBlogFromCreateDTO();
           await _blogRepo.CreateAsync(blogModel);
            return CreatedAtAction(nameof(GetById), new {id = blogModel.ID},blogModel.ToBlogDTO());
        }

        //update blog
        [HttpPut]
        [Route("{id}")]

        public async Task<IActionResult> Update([FromRoute] int id,[FromBody] UpdateBlogRequestDto updateDto){
            var blogModel = await _blogRepo.UpdateAsync(id,updateDto);

            if(blogModel == null){
                return NotFound();
            }

            return Ok(blogModel.ToBlogDTO());
        }

        //delete blog by id
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