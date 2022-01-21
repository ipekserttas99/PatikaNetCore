using BookStore.DBOperations;
using BookStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.UnitTests.TestSetup
{
    public static class Books
    {
        public static void AddBooks(this BookStoreDbContext context)
        {
            context.Books.AddRange(
                 new Book{Title = "Lean Startup",GenreId = 1,PageCount = 200,AuthorId = 1,IsActive = false,PublishDate = new DateTime(2001, 06, 12)},
                 new Book{Title = "Herland",GenreId = 2,PageCount = 250,AuthorId = 2,PublishDate = new DateTime(2010, 05, 23)},
                 new Book{Title = "Dune",GenreId = 2,PageCount = 540,AuthorId = 3,PublishDate = new DateTime(2001, 12, 21)},
                 new Book{Title = "God Of River",GenreId = 3,PageCount = 440,AuthorId = 4,PublishDate = new DateTime(1997, 12, 21)});
        }
    }
}
