using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    [Serializable]
    public class BookDto
    {
        public int ID { get; init; }
        public string Title { get; init; }
        public decimal Price { get; init; }
        public string ISBN { get; init; }
        public string AuthorName { get; init; }
        public string CategoryName { get; init; }
        public int Count { get; init; }
    }
}
