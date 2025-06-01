using Entities.Models;

namespace Repositories.Contracts
{
    public interface ILogEntryRepository : IRepositoryBase<LogEntry>
    {
        Task<IEnumerable<LogEntry>> GetAllLogsAsync(bool trackChanges);
        Task<LogEntry> GetLogAsync(int id, bool trackChanges);
        void CreateLog(LogEntry log);
        void DeleteLog(LogEntry log);
    }
}
