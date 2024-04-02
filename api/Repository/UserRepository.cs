using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Interfaces;
using api.Models;
using api.Data;
using Microsoft.EntityFrameworkCore;
using api.Dtos.User;

namespace api.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDBContext _context;

        public UserRepository(ApplicationDBContext context){
            _context = context;
        }

        public async Task<User> CreateAsync(User UserModel)
        {
            await _context.User.AddAsync(UserModel);
            await _context.SaveChangesAsync();
            return UserModel;        
        }

        public async Task<User?> DeleteAsync(int id)
        {
             var userModel = await _context.User.FirstOrDefaultAsync(x => x.ID == id);

            if(userModel == null){
                return null;
            }

            _context.User.Remove(userModel);
            await _context.SaveChangesAsync();
            return userModel;
        }

        public async Task<List<User>> GetAllAsync()
        {
           return await _context.User.ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.User.FindAsync(id);
        }

        public async Task<User?> UpdateAsync(int id, UpdateUserRequestDto UserDto)
        {
            var existingUser = await _context.User.FirstOrDefaultAsync(x => x.ID == id);

            if(existingUser == null){
                return null;
            }

            existingUser.Name = UserDto.Name;
            existingUser.Email = UserDto.Email;
            existingUser.Password = UserDto.Password;

            await _context.SaveChangesAsync();

            return existingUser;
        }
    }
}