using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IServiceManager
    {
        IBookService BookService { get; }
        IAuthorService AuthorService { get; }
        IBookCategoryService BookCategoryService { get; }
        INotificationService NotificationService { get; }
        IUserService UserService { get; }
        IBookBorrowRequestService BookBorrowService { get; }
        ILogEntryService LogEntryRepository { get; }
    }
}
