using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controller
{
    [Route("api/authors")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public AuthorsController(IServiceManager manager) => _manager = manager;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var authors = await _manager.AuthorService.GetAllAuthorsAsync(false);
            return Ok(authors);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Author author)
        {
            await _manager.AuthorService.CreateAuthorAsync(author);
            return CreatedAtAction(nameof(GetAll), null, author);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var author = await _manager.AuthorService.GetAuthorByIdAsync(id, false);
            if (author is null) return NotFound();
            return Ok(author);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _manager.AuthorService.DeleteAuthorAsync(id);
            return NoContent();
        }
    }
}
