using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class BookBorrowRequest
    {
        public int ID { get; set; }

        [Required]
        public string UserID { get; set; }
        public virtual User User { get; set; }

        [Required]
        public int BookID { get; set; }
        public virtual Book Book { get; set; }

        public DateTime StartDate { get; set; }
        public int DurationDays { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsAccepted { get; set; }
    }
}
