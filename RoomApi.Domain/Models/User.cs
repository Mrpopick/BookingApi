using RoomApi.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomApi.Domain.Models
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public DateTime CreatAt { get; set; } = DateTime.UtcNow;

        public Role Role { get; set; } = default!;

    }
}
