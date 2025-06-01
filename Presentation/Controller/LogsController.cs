using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Presentation.Controller
{
    [Route("api/logs")]
    [ApiController]
    public class LogsController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public LogsController(IServiceManager manager) => _manager = manager;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var logs = await _manager.LogEntryRepository.GetAllLogsAsync(false);
            return Ok(logs);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] LogEntry log)
        {
            _manager.LogEntryRepository.CreateLogAsync(log);
            return Ok(log);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var log = await _manager.LogEntryRepository.GetLogByIdAsync(id, false);
            if (log is null) return NotFound();
            return Ok(log);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _manager.LogEntryRepository.DeleteLogAsync(id);
            return NoContent();
        }
    }
}
