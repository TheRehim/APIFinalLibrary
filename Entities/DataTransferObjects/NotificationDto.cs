using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    [Serializable]
    public record NotificationDto
    {
        public int ID { get; init; }
        public string Message { get; init; }
        public DateTime CreatedAt { get; init; }
    }
}
