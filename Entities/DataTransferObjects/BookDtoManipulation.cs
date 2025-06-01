using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public abstract class BookDtoManipulation
    {
        [Required, MaxLength(100)]
        public string Title { get; init; }

        [Required]
        public decimal Price { get; init; }

        [Required, StringLength(13)]
        public string ISBN { get; init; }

        [Required]
        public int AuthorID { get; init; }

        [Required]
        public int CategoryID { get; init; }

        [Range(0, 10000)]
        public int Count { get; init; }

        public string PicturePath { get; init; }
    }
}
