using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDDSample1.Infrastructure;
using Domain.Users;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure.Users
{
    public  class UserRepository
    {
        private readonly DDDSample1DbContext _context;
        public UserRepository(DDDSample1DbContext context)
        {
            _context = context;
        }


        public async Task AddAsync(User user)
        {
            
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
        public async Task<User> GetByUserName(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Username.ToLower() == username.ToLower());
        }
        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Email.ToLower() == email.ToLower());
        }
    }

}