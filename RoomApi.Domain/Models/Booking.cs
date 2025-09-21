using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RoomApi.Domain.Models
{
    public class Booking
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid RoomId { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime EndAt { get; set; }
        public int RoomNumber { get; set; }
        [JsonIgnore]
        public Room Room { get; set; } = default!;
    }
}
