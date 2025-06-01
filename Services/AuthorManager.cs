using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class AuthorManager : IAuthorService
    {
        private readonly IRepositoryManager _repo;

        public AuthorManager(IRepositoryManager repo) => _repo = repo;

        public async Task<IEnumerable<Author>> GetAllAuthorsAsync(bool trackChanges) =>
            await _repo.Author.GetAllAuthorsAsync(trackChanges);

        public async Task<Author> GetAuthorByIdAsync(int id, bool trackChanges) =>
            await _repo.Author.GetAuthorAsync(id, trackChanges);

        public async Task CreateAuthorAsync(Author author)
        {
            _repo.Author.CreateAuthor(author);
            await _repo.SaveAsync();
        }

        public async Task DeleteAuthorAsync(int id)
        {
            var author = await _repo.Author.GetAuthorAsync(id, false);
            _repo.Author.DeleteAuthor(author);
            await _repo.SaveAsync();
        }
    }
}
