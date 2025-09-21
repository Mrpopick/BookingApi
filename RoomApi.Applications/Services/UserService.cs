using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RoomApi.Applications.DTOs;
using RoomApi.Applications.Interfaces;
using RoomApi.Domain.Models;
using RoomApi.Domain.Models.Enums;
using RoomApi.Infrastructure.DataBase;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace RoomApi.Applications.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;
        public UserService(AppDbContext context, IConfiguration configuration) 
        {
            _context = context;
            _configuration = configuration;
        }
        public async Task<User> CreateUserAsync(string username, string password, Role role)
        {
            if (_context.Users.Any(u => u.UserName == username))
                throw new NotImplementedException();

            var user = new User()
            {
                UserName = username,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(password),
                Role = role
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task DeleteUserAsync(string username)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);
            if (user == null)
                throw new NotImplementedException();
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<UserLoginDTO> LoggingAsync(string username, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == username);
            if (user is null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
                throw new NotImplementedException();

            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new(ClaimTypes.Name, user.UserName),
                new(ClaimTypes.Role, user.Role.ToString()),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return new UserLoginDTO() { UserName = user.UserName, Role = user.Role, AccessToken = jwt };
        }
    }
}
