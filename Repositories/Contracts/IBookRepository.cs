using Entities.Models;

namespace Repositories.Contracts
{
    public interface IBookRepository : IRepositoryBase<Book>
    {
        Task<IEnumerable<Book>> GetAllBooksAsync(bool trackChanges);
        Task<Book> GetBookAsync(int id, bool trackChanges);
        void CreateBook(Book book);
        void DeleteBook(Book book);

    }
}
