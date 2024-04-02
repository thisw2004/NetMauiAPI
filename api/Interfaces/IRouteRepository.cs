using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Route;
using api.Models;

namespace api.Interfaces
{
    public interface IRouteRepository
    {
        //routes instead of route bc 
        Task<List<Routes>> GetAllAsync();
        Task<Routes?> GetByIdAsync(int id);
        Task<Routes> CreateAsync(Routes RouteModel);
        Task<Routes?> UpdateAsync(int id,UpdateRouteRequestDto RouteDto);
        Task<Routes?> DeleteAsync(int id);
    }
}