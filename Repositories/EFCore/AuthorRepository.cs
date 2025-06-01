using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class AuthorRepository : RepositoryBase<Author>, IAuthorRepository
    {
        public AuthorRepository(RepositoryContext context) : base(context) { }

        public async Task<IEnumerable<Author>> GetAllAuthorsAsync(bool trackChanges) =>
            await FindAll(trackChanges).ToListAsync();

        public async Task<Author> GetAuthorAsync(int id, bool trackChanges) =>
            await FindByCondition(a => a.ID == id, trackChanges).SingleOrDefaultAsync();

        public void CreateAuthor(Author author) => Create(author);
        public void DeleteAuthor(Author author) => Delete(author);
    }
}
