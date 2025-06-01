using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Presentation.Controller
{
    [Route("api/categories")]
    [ApiController]
    public class BookCategoriesController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public BookCategoriesController(IServiceManager manager) => _manager = manager;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _manager.BookCategoryService.GetAllCategoriesAsync(false);
            return Ok(categories);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BookCategoryDto dto)
        {
            var created = await _manager.BookCategoryService.CreateCategoryAsync(dto);
            return CreatedAtAction(nameof(GetAll), null, created);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _manager.BookCategoryService.GetCategoryByIdAsync(id, false);
            if (category is null) return NotFound();
            return Ok(category);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _manager.BookCategoryService.DeleteCategoryAsync(id);
            return NoContent();
        }
    }
}
