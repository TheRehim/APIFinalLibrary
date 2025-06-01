using Entities.DataTransferObjects;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IBookService
    {
        Task<IEnumerable<BookDto>> GetAllBooksAsync(bool trackChanges, string userid);
        Task<BookDto> GetBookByIdAsync(int id, bool trackChanges);
        Task<BookDto> CreateBookAsync(BookDtoForInsertion dto);
        Task UpdateBookAsync(BookDtoUpdate dto);
        Task DeleteBookAsync(int id);
        Task<(Book bookEntity, BookDtoUpdate bookDto)> GetBookForPatchAsync(int id, bool trackChanges);
        Task SaveChangesForPatchAsync(Book bookEntity, BookDtoUpdate bookDto);
    }
}
