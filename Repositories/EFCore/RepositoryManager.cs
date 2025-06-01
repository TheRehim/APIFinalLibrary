using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private readonly Lazy<IBookRepository> _bookRepository;
        private readonly Lazy<IAuthorRepository> _authorRepository;
        private readonly Lazy<IBookCategoryRepository> _bookCategoryRepository;
        private readonly Lazy<INotificationRepository> _notificationRepository;
        private readonly Lazy<IBookBorrowRequestRepository> _bookBorrowRequestRepository;
        private readonly Lazy<ILogEntryRepository> _logEntryRepository;
        public RepositoryManager(RepositoryContext context)
        {
            _context = context;
            _bookRepository = new Lazy<IBookRepository>(() => new BookRepository(_context));
            _authorRepository = new Lazy<IAuthorRepository>(() => new AuthorRepository(_context));
            _bookCategoryRepository = new Lazy<IBookCategoryRepository>(() => new BookCategoryRepository(_context));
            _notificationRepository = new Lazy<INotificationRepository>(() => new NotificationRepository(_context));
            _bookBorrowRequestRepository = new Lazy<IBookBorrowRequestRepository>(() => new BookBorrowRequestRepository(_context));
            _logEntryRepository = new Lazy<ILogEntryRepository>(() => new LogEntryRepository(_context));
        }
        public IBookRepository Book => _bookRepository.Value;
        public IAuthorRepository Author => _authorRepository.Value;
        public IBookCategoryRepository BookCategory => _bookCategoryRepository.Value;
        public INotificationRepository Notification => _notificationRepository.Value;
        public IBookBorrowRequestRepository BookBorrow => _bookBorrowRequestRepository.Value;
        public ILogEntryRepository LogEntry => _logEntryRepository.Value;

        public void Save()
        {
            _context.SaveChanges();
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
