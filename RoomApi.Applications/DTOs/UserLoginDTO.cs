using RoomApi.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomApi.Applications.DTOs
{
    public class UserLoginDTO
    {
        public string UserName { get; set; } = default!;
        public Role Role { get; set; } = default!;
        public string AccessToken { get; set; } = default!;
        public string TokenType { get; set; } = "Bearer";
        public int ExpiresIn { get; set; } = 7200;
    }
}
