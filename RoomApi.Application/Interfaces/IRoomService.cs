using RoomApi.Application.DTos;
using RoomApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomApi.Application.Interfaces
{
    public interface IRoomService
    {
        public Task<Room> CreateRoomAsync(Room Room);
        public Task DeleteRoomAsync(Guid RoomId);

        public Task<ICollection<Room>> GetAllRoomsAsync();
    }
}
