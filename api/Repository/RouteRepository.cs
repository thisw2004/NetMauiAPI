using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Route;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;


namespace api.Repository
{
    public class RouteRepository : IRouteRepository
    {
        private readonly ApplicationDBContext _context;

        public RouteRepository(ApplicationDBContext context){
            _context = context;
        }

        public async Task<Routes> CreateAsync(Routes RouteModel)
        {
             await _context.Route.AddAsync(RouteModel);
            await _context.SaveChangesAsync();
            return RouteModel;
        }

        public async Task<Routes?> DeleteAsync(int id)
        {
            var routeModel = await _context.Route.FirstOrDefaultAsync(x => x.ID == id);

            if(routeModel == null){
                return null;
            }

            _context.Route.Remove(routeModel);
            await _context.SaveChangesAsync();
            return routeModel;
        }

        //here again routes instead of route bc microsoft..
        public async Task<List<Routes>> GetAllAsync()
        {
           return await _context.Route.ToListAsync();
        }

        public async Task<Routes?> GetByIdAsync(int id)
        {
            return await _context.Route.FindAsync(id);

        }

        public async Task<Routes?> UpdateAsync(int id, UpdateRouteRequestDto RouteDto)
        {
            var existingRoute = await _context.Route.FirstOrDefaultAsync(x => x.ID == id);

            if(existingRoute == null){
                return null;
            }

            existingRoute.Name = RouteDto.Name;
            existingRoute.Description = RouteDto.Description;
            existingRoute.Distance = RouteDto.Distance;
            existingRoute.StartPoint = RouteDto.StartPoint;
            existingRoute.EndPoint = RouteDto.EndPoint;

            await _context.SaveChangesAsync();

            return existingRoute;
        }
    }
}