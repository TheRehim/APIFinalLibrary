using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public record class BookBorrowRequestDtoUpdate : BookBorrowRequestDtoManipulation
    {
        [Required]
        public int ID { get; init; }
    }
}
