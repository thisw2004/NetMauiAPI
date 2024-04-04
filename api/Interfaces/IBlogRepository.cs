using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Blog;
using api.Helpers;
using api.Models;

namespace api.Interfaces
{
    public interface IBlogRepository
    {
        Task<List<Blog>> GetAllAsync();
        Task<Blog?> GetByIdAsync(int id);
        Task<Blog> CreateAsync(Blog blogModel);
        Task<Blog?> UpdateAsync(int id,UpdateBlogRequestDto blogDto);
        Task<Blog?> DeleteAsync(int id);
        
    }
}