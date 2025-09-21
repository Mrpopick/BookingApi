using RoomApi.Domain.Models;
using RoomApi.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomApi.Applications.DTOs
{
    public class RoomResponseDTO
    {
        public RoomClass RoomClass { get; set; }
        public int Number { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; } = default!;
    }
}
