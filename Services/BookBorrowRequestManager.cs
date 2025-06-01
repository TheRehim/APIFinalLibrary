using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BookBorrowRequestManager : IBookBorrowRequestService
    {
        private readonly IRepositoryManager _repo;
        private readonly IMapper _mapper;

        public BookBorrowRequestManager(IRepositoryManager repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookBorrowRequestDto>> GetAllRequestsAsync()
        {
            var requests = await _repo.BookBorrow.GetAllAsync(false);
            return _mapper.Map<IEnumerable<BookBorrowRequestDto>>(requests);
        }

        public async Task<IEnumerable<BookBorrowRequestDto>> GetUserLoanHistoryAsync(string userId)
        {
            var data = await _repo.BookBorrow.GetByUserAsync(userId, false);
            return _mapper.Map<IEnumerable<BookBorrowRequestDto>>(data);
        }

        public async Task<BookBorrowRequestDto> RequestLoanAsync(BookBorrowRequestDto dto)
        {
            var entity = _mapper.Map<BookBorrowRequest>(dto);
            _repo.BookBorrow.Create(entity);
            await _repo.SaveAsync();
            return _mapper.Map<BookBorrowRequestDto>(entity);
        }

        public async Task ReturnBookAsync(int requestId)
        {
            var req = await _repo.BookBorrow.GetByIdAsync(requestId, true);
            req.IsAccepted = false;
            await _repo.SaveAsync();
        }
    }

}
