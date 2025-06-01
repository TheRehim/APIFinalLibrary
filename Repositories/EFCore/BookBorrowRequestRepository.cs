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
    public class BookBorrowRequestRepository : RepositoryBase<BookBorrowRequest>, IBookBorrowRequestRepository
    {
        public BookBorrowRequestRepository(RepositoryContext context) : base(context) { }

        public async Task<IEnumerable<BookBorrowRequest>> GetAllAsync(bool trackChanges) =>
            await FindAll(trackChanges).ToListAsync();

        public async Task<BookBorrowRequest> GetByIdAsync(int id, bool trackChanges) =>
            await FindByCondition(x => x.ID == id, trackChanges).SingleOrDefaultAsync();

        public async Task<IEnumerable<BookBorrowRequest>> GetByUserAsync(string userId, bool trackChanges) =>
            await FindByCondition(x => x.UserID == userId, trackChanges).ToListAsync();
    }
}
