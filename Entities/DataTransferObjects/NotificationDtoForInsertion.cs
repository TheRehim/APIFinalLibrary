using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public record NotificationDtoForInsertion
    {
        [Required, MaxLength(250)]
        public string Message { get; init; }

        [Required]
        public string UserID { get; init; }
    }
}
