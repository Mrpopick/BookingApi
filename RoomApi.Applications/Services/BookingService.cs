using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using RoomApi.Applications.DTOs;
using RoomApi.Applications.Interfaces;
using RoomApi.Domain.Models;
using RoomApi.Infrastructure.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RoomApi.Applications.Services
{
    public class BookingService : IBookingService
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _accesor;
        public BookingService(AppDbContext context, IHttpContextAccessor accessor) 
        {
            _context = context; 
            _accesor = accessor;
        }
        public async Task<Booking> CreateBookingAsync(BookingCreateDTO BookingDTO)
        {
            var room = await _context.Rooms
                .Include(b => b.Bookings)
                .FirstOrDefaultAsync(r => r.Number == BookingDTO.RoomNumber);

            if (room == null)
                throw new Exception("Room is not find");

            if (room.Bookings.Any(b => b.CreatedAt < BookingDTO.EndAt && b.EndAt > BookingDTO.CreatedAt))
                return null;

            var userId = _accesor.HttpContext?.User
                                 .FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
                throw new UnauthorizedAccessException("User Unauthorize");

            var booking = new Booking()
            {
                RoomId = room.Id,
                UserId = Guid.Parse(userId),
                RoomNumber = room.Number,
                CreatedAt = BookingDTO.CreatedAt,
                EndAt = BookingDTO.EndAt

            };

            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
            return booking;


        }

        public async Task<ICollection<BookingResponceDTO>> GetAllBookingsAsync()
        {

            var userId = _accesor.HttpContext?.User
                                 .FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
                throw new UnauthorizedAccessException("User Unauthorize");

            var bookings = await _context.Bookings
                .Select(s => new BookingResponceDTO
            {
                CreatedAt = s.CreatedAt,
                EndAt = s.EndAt,
                RoomNumber = s.RoomNumber
            }).ToListAsync();

            return bookings;
        }
    }
}
