using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using api.Data;
using api.Mappers;
using api.Dtos.Route;

namespace api.Controllers
{
   [Route("api/routes")] //user or users? all users bc otherwise you need to specify an id 
    [ApiController]
    public class RouteController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public RouteController(ApplicationDBContext context){

            _context = context;
        }

        //get all users
        [HttpGet]
        public IActionResult GetAll()
        {
            var routes = _context.Route.ToList()
            .Select(s => s.ToRouteDTO()); //?

            return Ok(routes);
        }

        //get 1 user
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var route = _context.Route.Find(id);

            if(route == null){
                return NotFound();
            }

            return Ok(route.ToRouteDTO());

            //return Ok(users);
        }

        
        [HttpPost]
        public IActionResult Create([FromBody] CreateRouteRequestDto routeDTO){
            var routeModel = routeDTO.ToRouteFromCreateDTO();
            _context.Route.Add(routeModel);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new {id = routeModel.ID},routeModel.ToRouteDTO());
        }

        [HttpPut]
        [Route("{id}")]

        public IActionResult Update([FromRoute] int id,[FromBody] UpdateRouteRequestDto updateDto){
            var routeModel = _context.Route.FirstOrDefault(x => x.ID == id);

            if(routeModel == null){
                return NotFound();
            }

            routeModel.Name = updateDto.Name;
            routeModel.Description = updateDto.Description;
            routeModel.Distance = updateDto.Distance;
            routeModel.StartPoint = updateDto.StartPoint;
            routeModel.EndPoint = updateDto.EndPoint;

            _context.SaveChanges();

            return Ok(routeModel.ToRouteDTO());
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id){

            
            var routeModel = _context.Route.FirstOrDefault(x => x.ID == id);

            if(routeModel == null){
                return NotFound();
            }

            _context.Route.Remove(routeModel);

            _context.SaveChanges();

            return NoContent();
        }
    }
}