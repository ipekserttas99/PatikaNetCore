using BookStore.DBOperations;
using System;
using System.Linq;

namespace BookStore.Application.AuthorOperations.Commands.DeleteAuthor
{
    public class DeleteAuthorCommand
    {
        private readonly IBookStoreDbContext _dbContext;
        public int AuthorId { get; set; }
        public DeleteAuthorCommand(IBookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var author = _dbContext.Authors.SingleOrDefault(x => x.Id == AuthorId);
            if (author is null)
                throw new InvalidOperationException("Silinecek yazar bulunamadı!");
            if (author.BookId == AuthorId)
                throw new InvalidOperationException("Kitabı yayında olan bir yazarı silemezsiniz! Önce kitabı siliniz.");

            _dbContext.Authors.Remove(author);
            _dbContext.SaveChanges();
        }
    }
}
