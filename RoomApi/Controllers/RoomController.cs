using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RoomApi.Applications.DTOs;
using RoomApi.Applications.Interfaces;
using RoomApi.Domain.Models;
using RoomApi.Domain.Models.Enums;

namespace RoomApi.Controllers
{
    [ApiController]
    [Route("rooms")]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;
        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }
        [HttpPost("create")]
        [Authorize(Roles = nameof(Role.Admin))]
        public async Task<IActionResult> Create([FromBody]RoomCreateDTO roomCreateDTO)
        {
            try
            {
                var room = await _roomService.CreateRoomAsync(roomCreateDTO);
                return Ok(room);
            }
            catch (NotImplementedException)
            {
                return BadRequest("Room already exist");
            }
        }

        [HttpDelete("delete")]
        [Authorize(Roles = nameof(Role.Admin))]
        public async Task<IActionResult> Delete(int roomNumber)
        {
            try
            {
                await _roomService.DeleteRoomByIdAsync(roomNumber);
                return Ok();
            }
            catch (NotImplementedException)
            {
                return BadRequest("Room not find");
            }
        }

        [HttpGet("get-all-rooms")]
        [Authorize(Roles = nameof(Role.Admin))]
        public async Task<IActionResult> GetAllRooms()
        {
            try
            {
                var rooms = await _roomService.GetAllRoomsAsync();
                return Ok(rooms);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("debug/claims")]
        [Authorize]
        public IActionResult Claims() =>
                Ok(User.Claims.Select(x => new { x.Type, x.Value }));
    }
}
