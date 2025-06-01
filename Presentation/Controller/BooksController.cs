using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System.Security.Claims;

namespace Presentation.Controller
{
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private readonly IServiceManager _manager;
        public BooksController(IServiceManager manager)
        {
            _manager = manager;
        }
        [Authorize (Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var books = await _manager.BookService.GetAllBooksAsync(trackChanges: false, userId);
            return Ok(books);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var book = await _manager.BookService.GetBookByIdAsync(id, trackChanges: false);
            return Ok(book);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] BookDtoForInsertion dto)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var created = await _manager.BookService.CreateBookAsync(dto);
            return CreatedAtAction(nameof(GetBookById), new { id = created.ID }, created);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateBook([FromBody] BookDtoUpdate dto)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            await _manager.BookService.UpdateBookAsync(dto);
            return CreatedAtAction(nameof(GetBookById), new { id = dto.ID }, dto);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            await _manager.BookService.DeleteBookAsync(id);
            return NoContent();
        }
        [HttpPatch("{id:int}")]
        public async Task<IActionResult> PatchBook(int id, [FromBody] JsonPatchDocument<BookDtoUpdate> patchDoc)
        {
            if (patchDoc is null)
                return BadRequest();

            var (bookEntity, bookToPatch) = await _manager.BookService.GetBookForPatchAsync(id, trackChanges: true);

            patchDoc.ApplyTo(bookToPatch, ModelState);
            TryValidateModel(bookToPatch);

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            await _manager.BookService.SaveChangesForPatchAsync(bookEntity, bookToPatch);
            return NoContent();
        }
    }
}
