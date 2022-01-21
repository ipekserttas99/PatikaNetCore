using AutoMapper;
using BookStore.Entities;
using static BookStore.Application.AuthorOperations.Commands.CreateAuthor.CreateAuthorCommand;
using static BookStore.Application.AuthorOperations.Commands.UpdateAuthor.UpdateAuthorCommand;
using static BookStore.Application.AuthorOperations.Queries.GetAuthors.GetAuthorsQuery;
using static BookStore.Application.GenreOperations.Commands.CreateGenre.CreateGenreCommand;
using static BookStore.Application.GenreOperations.Commands.UpdateGenre.UpdateGenreCommand;
using static BookStore.Application.GenreOperations.Queries.GetGenreDetail.GetGenreDetailQuery;
using static BookStore.Application.GenreOperations.Queries.GetGenres.GetGenresQuery;
using static BookStore.BookOperations.CreateBook.CreateBookCommand;
using static BookStore.BookOperations.GetBooks.GetBookByIdQuery;
using static BookStore.BookOperations.GetBooks.GetBooksQuery;
using static BookStore.BookOperations.UpdateBook.UpdateBookCommand;

namespace BookStore.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, BooksDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
            CreateMap<Book, UpdateBookModel>();
            CreateMap<UpdateBookModel, Book>();

            CreateMap<Genre, GenresViewModel>();
            CreateMap<CreateGenreModel, Genre>();
            CreateMap<Genre, UpdateGenreModel>();
            CreateMap<UpdateGenreModel, Genre>();
            CreateMap<Genre, GenreDetailViewModel>();

            CreateMap<Author, AuthorsViewModel>();
            CreateMap<CreateAuthorModel, Author>();
            CreateMap<Author, UpdateAuthorModel>();
            CreateMap<UpdateAuthorModel, Author>();
        }

    }
}
