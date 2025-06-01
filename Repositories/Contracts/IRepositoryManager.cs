
namespace Repositories.Contracts
{
    public interface IRepositoryManager
    {
        IBookRepository Book { get; }
        IAuthorRepository Author { get; }
        IBookCategoryRepository BookCategory { get; }
        INotificationRepository Notification { get; }
        IBookBorrowRequestRepository BookBorrow { get; }
        ILogEntryRepository LogEntry { get; }
        void Save();
        Task SaveAsync();
    }
}