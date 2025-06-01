using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Notification
    {
        public int ID { get; set; }
        public string Message { get; set; }

        public string UserID { get; set; }
        public virtual User? User { get; set; }

        public DateTime CreatedAt { get; set; }
        public bool IsRead { get; set; }
    }

}
