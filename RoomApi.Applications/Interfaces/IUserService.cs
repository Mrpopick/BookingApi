using RoomApi.Applications.DTOs;
using RoomApi.Domain.Models;
using RoomApi.Domain.Models.Enums;


namespace RoomApi.Applications.Interfaces
{
    public interface IUserService
    {
        public Task<User> CreateUserAsync(string username, string password, Role role);
        public Task<UserLoginDTO> LoggingAsync(string username, string password);
        public Task DeleteUserAsync(string username);
    }
}
