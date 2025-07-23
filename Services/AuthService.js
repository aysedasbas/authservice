using AuthService.Data;
using AuthService.Models;
using Microsoft.AspNetCore.Identity;

namespace AuthService.Services
{
    public class AuthService
    {
        private readonly AppDbContext _context;
        private readonly PasswordHasher<User> _passwordHasher;

        public AuthService(AppDbContext context)
        {
            _context = context;
            _passwordHasher = new PasswordHasher<User>();
        }

        public async Task<User> RegisterAsync(User user, string password)
        {
            user.PasswordHash = _passwordHasher.HashPassword(user, password);
            user.Role = "User"; // varsayılan rol

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }
    }
}
