using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public record AuthResponseDto
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
