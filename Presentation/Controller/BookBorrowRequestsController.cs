using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controller
{
    [Route("api/borrowrequests")]
    [ApiController]
    public class BookBorrowRequestsController : ControllerBase
    {
        private readonly IServiceManager _manager;
        public BookBorrowRequestsController(IServiceManager manager) => _manager = manager;

        [HttpPost]
        public async Task<IActionResult> RequestLoan([FromBody] BookBorrowRequestDto dto)
        {
            var result = await _manager.BookBorrowService.RequestLoanAsync(dto);
            return Ok(result);
        }

        [HttpPost("return/{id:int}")]
        public async Task<IActionResult> ReturnBook(int id)
        {
            await _manager.BookBorrowService.ReturnBookAsync(id);
            return NoContent();
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetUserHistory(string userId)
        {
            var history = await _manager.BookBorrowService.GetUserLoanHistoryAsync(userId);
            return Ok(history);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _manager.BookBorrowService.GetAllRequestsAsync());
    }

}
