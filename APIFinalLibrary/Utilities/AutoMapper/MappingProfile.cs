using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;

namespace APIFinalLibrary.Utilities.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookDto>()
                .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author.FullName))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));
            CreateMap<BookDtoForInsertion, Book>();
            CreateMap<BookDto, Book>();
            CreateMap<BookDtoUpdate, Book>().ReverseMap();

            CreateMap<BookBorrowRequest, BookBorrowRequestDto>();
            CreateMap<BookBorrowRequestDtoForInsertion, BookBorrowRequest>();
            CreateMap<BookBorrowRequestDtoUpdate, BookBorrowRequest>().ReverseMap();

            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<UserForUpdateDto, User>();
            CreateMap<UserForAuthenticationDto, User>();

            CreateMap<BookCategory, BookCategoryDto>().ReverseMap();

            CreateMap<Notification, NotificationDto>().ReverseMap();

        }
    }
}
