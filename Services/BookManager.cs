using AutoMapper;
using Entities.DataTransferObjects;
using Entities.ErrorModel;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class BookManager : IBookService
    {
        private readonly IRepositoryManager _manager;
        private readonly ILoggerService _logger;
        private readonly ILogEntryService _logEntry;
        private readonly IMapper _mapper;

        public BookManager(IRepositoryManager repository, ILoggerService logger, IMapper mapper, ILogEntryService logEntry)
        {
            _manager = repository;
            _logger = logger;
            _logEntry = logEntry;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookDto>> GetAllBooksAsync(bool trackChanges, string userid)
        {
            var books = await _manager.Book.GetAllBooksAsync(trackChanges);
            _logger.LogInfo($"Fetched all books. Count: {books.Count()}");
            await _logEntry.WriteLogAsync(userid, "Get Books", true, $"Books count '{books.Count()}' called.");
            return _mapper.Map<IEnumerable<BookDto>>(books);
        }

        public async Task<BookDto> GetBookByIdAsync(int id, bool trackChanges)
        {
            var book = await _manager.Book.GetBookAsync(id, trackChanges)
                       ?? throw new BookNotFoundException(id);

            _logger.LogInfo($"Fetched book with ID {id}: {book.Title}");
            return _mapper.Map<BookDto>(book);
        }

        public async Task<BookDto> CreateBookAsync(BookDtoForInsertion dto)
        {
            var book = _mapper.Map<Book>(dto);
            _manager.Book.CreateBook(book);
            await _manager.SaveAsync();

            _logger.LogInfo($"Created new book: {book.Title}");

            return _mapper.Map<BookDto>(book);
        }

        public async Task UpdateBookAsync(BookDtoUpdate dto)
        {
            var book = await _manager.Book.GetBookAsync(dto.ID, trackChanges: true)
                       ?? throw new BookNotFoundException(dto.ID);

            _mapper.Map(dto, book);
            await _manager.SaveAsync();

            _logger.LogInfo($"Updated book: {book.Title}");
        }

        public async Task DeleteBookAsync(int id)
        {
            var book = await _manager.Book.GetBookAsync(id, trackChanges: false)
                       ?? throw new BookNotFoundException(id);

            _manager.Book.DeleteBook(book);
            await _manager.SaveAsync();

            _logger.LogInfo($"Deleted book: {book.Title}");
        }

        public async Task<(Book bookEntity, BookDtoUpdate bookDto)> GetBookForPatchAsync(int id, bool trackChanges)
        {
            var book = await _manager.Book.GetBookAsync(id, trackChanges)
                       ?? throw new BookNotFoundException(id);

            var bookDto = _mapper.Map<BookDtoUpdate>(book);

            _logger.LogInfo($"Fetched book for patch: {book.Title}");

            return (book, bookDto);
        }

        public async Task SaveChangesForPatchAsync(Book bookEntity, BookDtoUpdate bookDto)
        {
            _mapper.Map(bookDto, bookEntity);
            await _manager.SaveAsync();

            _logger.LogInfo($"Patched book: {bookEntity.Title}");
        }
    }
}
