using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
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

        //here again routes instead of route bc microsoft..
        public Task<List<Routes>> GetAllAsync()
        {
           return _context.Route.ToListAsync();
        }
    }
}