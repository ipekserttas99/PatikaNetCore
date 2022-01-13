using AutoMapper;
using BookStore.DBOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.BookOperations.UpdateBook
{
    public class UpdateBookCommand
    {
        public UpdateBookModel Model { get; set; }
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public int BookId { get; set; }
        public UpdateBookCommand(BookStoreDbContext dbContext,IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle(UpdateBookModel updateBookModel)
        {
            var book = _dbContext.Books.Where(book => book.Id == BookId).SingleOrDefault();
            if (book is null)
                throw new InvalidOperationException("Kitap bulunamadı");

            _mapper.Map(updateBookModel, book);
            _dbContext.SaveChanges();
        } 

        public class UpdateBookModel
        {
            public string Title { get; set; }
            public int GenreId { get; set; }
        }
    }
}
