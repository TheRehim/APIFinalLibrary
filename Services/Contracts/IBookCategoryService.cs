using Entities.DataTransferObjects;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IBookCategoryService
    {
        Task<IEnumerable<BookCategory>> GetAllCategoriesAsync(bool trackChanges);
        Task<BookCategory> GetCategoryByIdAsync(int id, bool trackChanges);
        Task<BookCategoryDto> CreateCategoryAsync(BookCategoryDto dto);
        Task DeleteCategoryAsync(int id);
    }
}
