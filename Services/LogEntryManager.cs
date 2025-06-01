using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class LogEntryManager : ILogEntryService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public LogEntryManager(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LogEntry>> GetAllLogsAsync(bool trackChanges)
        {
            return await _repository.LogEntry.GetAllLogsAsync(trackChanges);
        }

        public async Task<LogEntry> GetLogByIdAsync(int id, bool trackChanges)
        {
            return await _repository.LogEntry.GetLogAsync(id, trackChanges);
        }

        public async Task<LogEntry> CreateLogAsync(LogEntry log)
        {
            _repository.LogEntry.CreateLog(log);
            await _repository.SaveAsync();
            return log;
        }

        public async Task DeleteLogAsync(int id)
        {
            var log = await _repository.LogEntry.GetLogAsync(id, false);
            if (log != null)
            {
                _repository.LogEntry.DeleteLog(log);
                await _repository.SaveAsync();
            }
        }
        public async Task WriteLogAsync(string userId, string action, bool isSuccess, string message, string? details = null)
        {
            var log = new LogEntry
            {
                UserID = userId,
                Action = action,
                Message = message,
                Details = details,
                Timestamp = DateTime.UtcNow
            };
            _repository.LogEntry.CreateLog(log);
            await _repository.SaveAsync();
        }

    }
}
