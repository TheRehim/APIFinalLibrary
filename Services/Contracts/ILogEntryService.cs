using Entities.DataTransferObjects;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface ILogEntryService
    {
        Task<IEnumerable<LogEntry>> GetAllLogsAsync(bool trackChanges);
        Task<LogEntry> GetLogByIdAsync(int id, bool trackChanges);
        Task<LogEntry> CreateLogAsync(LogEntry log);
        Task DeleteLogAsync(int id);
        Task WriteLogAsync(string userId, string action, bool isSuccess, string message, string? details = null);
    }
}
