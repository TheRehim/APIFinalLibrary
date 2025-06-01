using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IBookBorrowRequestRepository : IRepositoryBase<BookBorrowRequest>
    {
        Task<IEnumerable<BookBorrowRequest>> GetAllAsync(bool trackChanges);
        Task<BookBorrowRequest> GetByIdAsync(int id, bool trackChanges);
        Task<IEnumerable<BookBorrowRequest>> GetByUserAsync(string userId, bool trackChanges);
    }
}
