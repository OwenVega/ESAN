using System;
using System.Collections.Generic;
using System.Text;
using UESAN.SHOPPING.CORE.Infrastructure.Data;
using UESAN.SHOPPING.CORE.Core.Interfaces;
using UESAN.SHOPPING.CORE.Core.DTOs;
using UESAN.SHOPPING.CORE.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace UESAN.SHOPPING.CORE.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly StoreDbContext _context;

        public UserRepository(StoreDbContext context)
        {
            _context = context;
        }


        public async Task<User> SingIn(string email, string contra)
        {
            return await _context.User.FirstOrDefaultAsync(u => u.Email == email && u.Password == contra);
        }

        public async Task<int> SignupIn(User user)
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();
            return user.Id;
        }
    }
}
