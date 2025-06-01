using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Author
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public virtual ICollection<Book> Books { get; set; }

    }
}
