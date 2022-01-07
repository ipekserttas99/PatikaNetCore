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

        public UpdateBookCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle(int id, UpdateBookModel updateBookModel)
        {
            var book = _dbContext.Books.SingleOrDefault(x => x.Id == id);
            if (book is null)
                throw new InvalidOperationException("Kitap bulunamadı");

            book.GenreId = updateBookModel.GenreId != default /*yani verisi doldurulmuşsa*/ ? updateBookModel.GenreId : /*eğer doldurulmamışsa kendisinin(önceki veriyi) koy*/ book.GenreId;
            book.PageCount = updateBookModel.PageCount != default ? updateBookModel.PageCount : book.PageCount;
            book.Title = updateBookModel.Title != default ? updateBookModel.Title : book.Title;
            book.PublishDate = updateBookModel.PublishDate != default ? updateBookModel.PublishDate : updateBookModel.PublishDate;

            _dbContext.SaveChanges();
        }

        public class UpdateBookModel
        {
            public string Title { get; set; }
            public int PageCount { get; set; }
            public DateTime PublishDate { get; set; }
            public int GenreId { get; set; }
        }
    }
}
