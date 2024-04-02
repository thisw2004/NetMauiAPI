using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using api.Data;
using api.Mappers;
using api.Dtos.Route;
using Microsoft.EntityFrameworkCore;
using api.Interfaces;
using api.Models;

namespace api.Controllers
{
   [Route("api/routes")] //user or users? all users bc otherwise you need to specify an id 
    [ApiController]
    public class RouteController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IRouteRepository _routeRepo;

        public RouteController(ApplicationDBContext context,IRouteRepository routeRepo){

            _routeRepo = routeRepo;
            _context = context;
        }

        //get all users
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var  routes = await _routeRepo.GetAllAsync();
            var routesdto = routes.Select(s => s.ToRouteDTO()); //?

            return Ok(routes);
        }

        //get 1 user
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var route = await _context.Route.FindAsync(id);

            if(route == null){
                return NotFound();
            }

            return Ok(route.ToRouteDTO());

            //return Ok(users);
        }

        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateRouteRequestDto routeDTO){
            var routeModel = routeDTO.ToRouteFromCreateDTO();
            await _context.Route.AddAsync(routeModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new {id = routeModel.ID},routeModel.ToRouteDTO());
        }

        [HttpPut]
        [Route("{id}")]

        public async Task<IActionResult> Update([FromRoute] int id,[FromBody] UpdateRouteRequestDto updateDto){
            var routeModel = await _context.Route.FirstOrDefaultAsync(x => x.ID == id);

            if(routeModel == null){
                return NotFound();
            }

            routeModel.Name = updateDto.Name;
            routeModel.Description = updateDto.Description;
            routeModel.Distance = updateDto.Distance;
            routeModel.StartPoint = updateDto.StartPoint;
            routeModel.EndPoint = updateDto.EndPoint;

            await _context.SaveChangesAsync();

            return Ok(routeModel.ToRouteDTO());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult>Delete([FromRoute] int id){

            
            var routeModel = await _context.Route.FirstOrDefaultAsync(x => x.ID == id);

            if(routeModel == null){
                return NotFound();
            }

            _context.Route.Remove(routeModel);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}