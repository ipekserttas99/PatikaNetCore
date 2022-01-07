using BookStore.Common;
using BookStore.DBOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.BookOperations.GetBooks
{
    public class GetBookByIdQuery
    {
        private readonly BookStoreDbContext _dbContext;

        public GetBookByIdQuery(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<BooksViewModel> Handle(int id)
        {
            var book = _dbContext.Books.Where(book => book.Id == id).SingleOrDefault();
            List<BooksViewModel> booksView = new List<BooksViewModel>();
            booksView.Add(new BooksViewModel()
            {
                  Title = book.Title,
                  PageCount = book.PageCount,
                  PublishDate = book.PublishDate.ToString("dd/MM/yyyy"),
                  Genre = ((GenreEnum)book.GenreId).ToString()
             });
            return booksView;
            
        }
        public class BooksViewModel
        {
            public string Title { get; set; }
            public int PageCount { get; set; }
            public string PublishDate { get; set; }
            public string Genre { get; set; }
        }
    }
}
