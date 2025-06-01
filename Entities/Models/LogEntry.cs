using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class LogEntry
    {
        public int ID { get; set; }
        public string UserID { get; set; }
        public virtual User User { get; set; }
        public string Action { get; set; }
        public string Message { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public string? Details { get; set; }
    }

}
