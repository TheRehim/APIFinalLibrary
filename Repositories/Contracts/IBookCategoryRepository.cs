using Entities.DataTransferObjects;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IBookCategoryRepository : IRepositoryBase<BookCategory>
    {
        Task<IEnumerable<BookCategory>> GetAllCategoriesAsync(bool trackChanges);
        Task<BookCategory> GetCategoryAsync(int id, bool trackChanges);
        void CreateCategory(BookCategory category);
        void DeleteCategory(BookCategory category);
    }

}
