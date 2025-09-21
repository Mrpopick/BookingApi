using Microsoft.EntityFrameworkCore;
using RoomApi.Applications.DTOs;
using RoomApi.Applications.Interfaces;
using RoomApi.Domain.Models;
using RoomApi.Infrastructure.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomApi.Applications.Services
{
    public class RoomService : IRoomService
    {
        private readonly AppDbContext _context;
        public RoomService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Room> CreateRoomAsync(RoomCreateDTO RoomDTO)
        {
            var room = await _context.Rooms.FirstOrDefaultAsync(x => x.Number == RoomDTO.RoomNumber);
            if (room != null)
                throw new NotImplementedException();

            var newRoom = new Room()
            {
                Number = RoomDTO.RoomNumber,
                Price = RoomDTO.Price,
                Description = RoomDTO.Description
            };

            _context.Rooms.Add(newRoom);
            await _context.SaveChangesAsync();

            return newRoom;

        }

        public async Task DeleteRoomByIdAsync(int RoomNumber)
        {
            var room = await _context.Rooms.FirstOrDefaultAsync(x => x.Number == RoomNumber);

            if (room == null)
                throw new NotImplementedException();

            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();

        }

        public async Task<ICollection<RoomResponseDTO>> GetAllRoomsAsync()
        {
            var rooms = await _context.Rooms
                .Select(x => new RoomResponseDTO
            {
                RoomClass = x.RoomClass,
                Price = x.Price,
                Description = x.Description,
                Number = x.Number
                
            }).ToListAsync();

            return rooms;
        }
    }
}
