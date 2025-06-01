using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class LogEntryRepository : RepositoryBase<LogEntry>, ILogEntryRepository
    {
        public LogEntryRepository(RepositoryContext context) : base(context) { }

        public void CreateLog(LogEntry log) => Create(log);

        public void DeleteLog(LogEntry log) => Delete(log);

        public async Task<IEnumerable<LogEntry>> GetAllLogsAsync(bool trackChanges) =>
            await FindAll(trackChanges)
                .Include(l => l.User)
                .ToListAsync();

        public async Task<LogEntry> GetLogAsync(int id, bool trackChanges) =>
            await FindByCondition(l => l.ID == id, trackChanges)
                .Include(l => l.User)
                .SingleOrDefaultAsync();
    }
}
