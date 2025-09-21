using RoomApi.Domain.Models.Enums;


namespace RoomApi.Applications.DTOs
{
    public class RoomCreateDTO
    {
        public RoomClass RoomClass { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; } = default!;
        public int RoomNumber { get; set; }
    }
}
