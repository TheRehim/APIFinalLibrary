using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BookCategoryManager : IBookCategoryService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public BookCategoryManager(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookCategory>> GetAllCategoriesAsync(bool trackChanges)
        {
            return await _repository.BookCategory.GetAllCategoriesAsync(trackChanges);
        }

        public async Task<BookCategory> GetCategoryByIdAsync(int id, bool trackChanges)
        {
            return await _repository.BookCategory.GetCategoryAsync(id, trackChanges);
        }

        public async Task<BookCategoryDto> CreateCategoryAsync(BookCategoryDto category)
        {
            var entity = _mapper.Map<BookCategory>(category);
            _repository.BookCategory.CreateCategory(entity);
            await _repository.SaveAsync();
            return _mapper.Map<BookCategoryDto>(entity);
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var category = await _repository.BookCategory.GetCategoryAsync(id, false);
            _repository.BookCategory.DeleteCategory(category);
            await _repository.SaveAsync();
        }
    }
}
