using AutoMapper;
using Repositories.Contracts;
using Repositories.EFCore;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IBookService> _bookService;
        private readonly Lazy<IAuthorService> _authorService;
        private readonly Lazy<IBookCategoryService> _bookCategoryService;
        private readonly Lazy<INotificationService> _notificationService;
        private readonly Lazy<IUserService> _userService;
        private readonly Lazy<IBookBorrowRequestService> _borrowService;
        private readonly Lazy<ILogEntryService> _logEntryService;

        public ServiceManager(IRepositoryManager repositoryManager,
                              ILoggerService logger,
                              IMapper mapper,
                              ILogEntryService logEntry,
                              Microsoft.AspNetCore.Identity.UserManager<Entities.Models.User> userManager)
        {
            _bookService = new Lazy<IBookService>(() => new BookManager(repositoryManager, logger, mapper, logEntry));
            _authorService = new Lazy<IAuthorService>(() => new AuthorManager(repositoryManager));
            _bookCategoryService = new Lazy<IBookCategoryService>(() => new BookCategoryManager(repositoryManager, mapper));
            _notificationService = new Lazy<INotificationService>(() => new NotificationManager(repositoryManager, mapper));
            _userService = new Lazy<IUserService>(() => new UserManager(userManager, mapper));
            _borrowService = new Lazy<IBookBorrowRequestService>(() => new BookBorrowRequestManager(repositoryManager, mapper));
            _logEntryService = new Lazy<ILogEntryService>(() => new LogEntryManager(repositoryManager, mapper));
        }
        public IBookService BookService => _bookService.Value;
        public IAuthorService AuthorService => _authorService.Value;
        public IBookCategoryService BookCategoryService => _bookCategoryService.Value;
        public INotificationService NotificationService => _notificationService.Value;
        public IUserService UserService => _userService.Value;
        public IBookBorrowRequestService BookBorrowService => _borrowService.Value;
        public ILogEntryService LogEntryRepository => _logEntryService.Value;

    }
}
