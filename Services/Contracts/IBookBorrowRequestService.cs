using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.DataTransferObjects;

namespace Services.Contracts
{
    public interface IBookBorrowRequestService
    {
        Task<IEnumerable<BookBorrowRequestDto>> GetAllRequestsAsync();
        Task<IEnumerable<BookBorrowRequestDto>> GetUserLoanHistoryAsync(string userId);
        Task<BookBorrowRequestDto> RequestLoanAsync(BookBorrowRequestDto dto);
        Task ReturnBookAsync(int requestId);
    }

}
