using RoomApi.Applications.DTOs;
using RoomApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomApi.Applications.Interfaces
{
    public interface IRoomService
    {
        public Task<Room> CreateRoomAsync(RoomCreateDTO RoomDTO);
        public Task DeleteRoomByIdAsync(int RoomNumber);
        public Task<ICollection<RoomResponseDTO>> GetAllRoomsAsync();

    }
}
