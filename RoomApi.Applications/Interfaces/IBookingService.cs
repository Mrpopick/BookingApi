using RoomApi.Applications.DTOs;
using RoomApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomApi.Applications.Interfaces
{
    public interface IBookingService
    {
        public Task<Booking> CreateBookingAsync(BookingCreateDTO BookingDTO);
        public Task<ICollection<BookingResponceDTO>> GetAllBookingsAsync();
    }
}
