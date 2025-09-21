using RoomApi.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomApi.Application.DTos
{
    public record CreateRoomDto
    {
        RoomClass RoomClass;
        decimal Price;
        string Description;
    }
}
