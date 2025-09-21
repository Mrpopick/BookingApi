using RoomApi.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RoomApi.Domain.Models
{
    public class Room
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public RoomClass RoomClass { get; set; }
        public int Number { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; } = default!;

        [JsonIgnore]
        public ICollection<Booking> Bookings { get; set; } = default!;
    }
}
