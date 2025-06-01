using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ErrorModel
{
    public sealed class BookNotFoundException : NotFoundException
    {
        public BookNotFoundException(int id) : base($"Kitap bulunamadı. ID: {id}")
        {

        }
    }
}
