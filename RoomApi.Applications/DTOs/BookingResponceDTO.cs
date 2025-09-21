using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomApi.Applications.DTOs
{
    public class BookingResponceDTO
    {
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime EndAt { get; set; }
        public int RoomNumber { get; set; }
    }
}
