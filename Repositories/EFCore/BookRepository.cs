using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(RepositoryContext context) : base(context) { }

        public async Task<IEnumerable<Book>> GetAllBooksAsync(bool trackChanges) =>
            await FindAll(trackChanges)
                .Include(b => b.Author)
                .Include(b => b.Category)
                .ToListAsync();

        public async Task<Book> GetBookAsync(int id, bool trackChanges) =>
            await FindByCondition(b => b.ID == id, trackChanges)
                .Include(b => b.Author)
                .Include(b => b.Category)
                .SingleOrDefaultAsync();


        public void CreateBook(Book book) => Create(book);

        public void DeleteBook(Book book) => Delete(book);

    }
}
