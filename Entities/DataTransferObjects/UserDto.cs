using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public record UserDto
    {
        public string ID { get; init; }
        public string UserName { get; init; }
        public string Email { get; init; }
        public string? Initials { get; init; }
    }
}
