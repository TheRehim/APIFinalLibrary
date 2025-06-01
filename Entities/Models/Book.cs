using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Book   
    {
        public int ID { get; set; }

        [Required, MaxLength(100)]
        public string Title { get; set; }

        [Required]
        public int AuthorID { get; set; }
        public virtual Author Author { get; set; }

        [Required, Range(0, 9999)]
        public decimal Price { get; set; }

        public DateOnly PublishDate { get; set; }
        public bool IsActive { get; set; }

        [Required]
        public int CategoryID { get; set; }
        public virtual BookCategory Category { get; set; }

        [Required, StringLength(13)]
        public string ISBN { get; set; }

        [Range(0, 10000)]
        public int Count { get; set; }

        public string PicturePath { get; set; }

        public virtual ICollection<BookBorrowRequest> BorrowRequests { get; set; } = new HashSet<BookBorrowRequest>();

    }
}
