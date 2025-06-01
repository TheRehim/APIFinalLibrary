using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public abstract record BookBorrowRequestDtoManipulation
    {
        [Required]
        public string UserID { get; init; }

        [Required]
        public int BookID { get; init; }

        [Required]
        public int DurationDays { get; init; }
    }

}
