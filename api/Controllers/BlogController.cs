using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using api.Data;

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
            var blogs = _context.Blog.ToList();

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

            return Ok(blog);

            //return Ok(users);
        }
    }
}