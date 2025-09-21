using RoomApi.Domain.Models;
using RoomApi.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RoomApi.Application.Interfaces
{
    public interface IBokingService
    {
        public Task<Room> CreateBookingAsync(Room room);
        public Task<ICollection<Booking>> GetAllBookingsAsync();
    }
}
