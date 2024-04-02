using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Blog;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class BlogRepository : IBlogRepository
    {
        private readonly ApplicationDBContext _context;

        public BlogRepository(ApplicationDBContext context){
            _context = context;
        }

        public async Task<Blog> CreateAsync(Blog blogModel)
        {
            await _context.Blog.AddAsync(blogModel);
            await _context.SaveChangesAsync();
            return blogModel;
        }

        public async Task<Blog?> DeleteAsync(int id)
        {
            var blogModel = await _context.Blog.FirstOrDefaultAsync(x => x.ID == id);

            if(blogModel == null){
                return null;
            }

            _context.Blog.Remove(blogModel);
            await _context.SaveChangesAsync();
            return blogModel;
        }

        public async Task<List<Blog>> GetAllAsync()
        {
           return await _context.Blog.ToListAsync();



        }

        public async Task<Blog?> GetByIdAsync(int id)
        {
            return await _context.Blog.FindAsync(id);
        }

        public async Task<Blog?> UpdateAsync(int id, UpdateBlogRequestDto blogDto)
        {
            var existingBlog = await _context.Blog.FirstOrDefaultAsync(x => x.ID == id);

            if(existingBlog == null){
                return null;
            }
            
            existingBlog.Author = blogDto.Author;
            existingBlog.Content = blogDto.Content;
            existingBlog.Title = blogDto.Title;

            await _context.SaveChangesAsync();

            return existingBlog;

        }
    }
}