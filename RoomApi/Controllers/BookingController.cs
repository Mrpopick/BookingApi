using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RoomApi.Applications.DTOs;
using RoomApi.Applications.Interfaces;
using RoomApi.Domain.Models.Enums;

namespace RoomApi.Controllers
{
    [ApiController]
    [Route("booking")]
    [Authorize]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] BookingCreateDTO bookingCreateDTO)
        {
            try
            {
                var booking = await _bookingService.CreateBookingAsync(bookingCreateDTO);
                if (booking == null)
                    return BadRequest("Booking already exist");
                return Ok(booking);
            }
            catch (UnauthorizedAccessException)
            {
                return BadRequest("Unauthorize user!");
            }
            catch (Exception)
            {
                return BadRequest("Room dosnt exist");
            }
            
        }

        

        [HttpGet("get-all-booking")]
        public async Task<IActionResult> GetAllBooking()
        {
            try
            {
                var bookings = await _bookingService.GetAllBookingsAsync();
                return Ok(bookings);
            }
            catch (UnauthorizedAccessException)
            {
                return BadRequest("User Unauthorize");
            }
        }
    }
}
