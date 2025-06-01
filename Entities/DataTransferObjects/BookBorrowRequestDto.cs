using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    [Serializable]
    public class BookBorrowRequestDto
    {
        public int ID { get; init; }
        public string BookTitle { get; init; }
        public string UserFullName { get; init; }
        public DateTime StartDate { get; init; }
        public DateTime EndDate { get; init; }
        public bool IsAccepted { get; init; }
    }
}
