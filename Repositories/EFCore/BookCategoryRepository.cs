using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class BookCategoryRepository : RepositoryBase<BookCategory>, IBookCategoryRepository
    {
        public BookCategoryRepository(RepositoryContext context) : base(context) { }

        public async Task<IEnumerable<BookCategory>> GetAllCategoriesAsync(bool trackChanges) =>
            await FindAll(trackChanges).ToListAsync();

        public async Task<BookCategory> GetCategoryAsync(int id, bool trackChanges) =>
            await FindByCondition(c => c.ID == id, trackChanges).SingleOrDefaultAsync();

        public void CreateCategory(BookCategory category) => Create(category);
        public void DeleteCategory(BookCategory category) => Delete(category);
    }
}
