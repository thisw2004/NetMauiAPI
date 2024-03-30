using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using api.Data;
using api.Mappers;
using api.Dtos.Blog;

namespace api.Controllers
{
    [Route("api/blogs")] //user or users? all users bc otherwise you need to specify an id 
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public BlogController(ApplicationDBContext context){

            _context = context;
        }

        //get all users
        [HttpGet]
        public IActionResult GetAll()
        {
            var blogs = _context.Blog.ToList()
            .Select(s => s.ToBlogDTO());

            return Ok(blogs);
        }

        //get 1 user
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var blog = _context.Blog.Find(id);

            if(blog == null){
                return NotFound();
            }

            return Ok(blog.ToBlogDTO());

            //return Ok(users);
        }
        
        // 6.
        [HttpPost]
        public IActionResult Create([FromBody] CreateBlogRequestDto blogDTO){
            var blogModel = blogDTO.ToBlogFromCreateDTO();
            _context.Blog.Add(blogModel);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new {id = blogModel.ID},blogModel.ToBlogDTO());
        }

        [HttpPut]
        [Route("{id}")]

        public IActionResult Update([FromRoute] int id,[FromBody] UpdateBlogRequestDto updateDto){
            var blogModel = _context.Blog.FirstOrDefault(x => x.ID == id);

            if(blogModel == null){
                return NotFound();
            }

            blogModel.Author = updateDto.Author;
            blogModel.Content = updateDto.Content;
            blogModel.Title = updateDto.Title;

            _context.SaveChanges();

            return Ok(blogModel.ToBlogDTO());
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id){
            var blogModel = _context.Blog.FirstOrDefault(x => x.ID == id);

            if(blogModel == null){
                return NotFound();
            }

            _context.Blog.Remove(blogModel);

            _context.SaveChanges();

            return NoContent();
        }
    }
}