using BookStore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace BookStore.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if (context.Books.Any())
                {
                    return;
                }

                context.Genres.AddRange(
                    new Genre
                    {
                        Name = "Personal Growth"
                    },
                    new Genre
                    {
                        Name = "Science Fiction"
                    },
                    new Genre
                    {
                        Name = "Romance"
                    }
                 );
                context.Authors.AddRange(
                    new Author
                    {
                        Name = "William",
                        Surname = "Shakespeare",
                        BookId = 1,
                        DateOfBirth = new DateTime(1564, 04, 01)
                    },
                    new Author
                    {
                        Name = "George",
                        Surname = "Orwell",
                        BookId = 2,
                        DateOfBirth = new DateTime(1903, 06, 25)
                    },
                    new Author
                    {
                        Name = "J.K.",
                        Surname = "Rowling",
                        BookId = 3,
                        DateOfBirth = new DateTime(1965, 07, 12)
                    },
                    new Author
                    {
                        Name = "Wilbur",
                        Surname = "Smith",
                        BookId = 4,
                        DateOfBirth = new DateTime(1933, 01, 09)
                    }
                 );

                context.Books.AddRange(
                    new Book
                    {
                        Title = "Lean Startup",
                        GenreId = 1,
                        PageCount = 200,
                        AuthorId = 1,
                        IsActive = false,
                        PublishDate = new DateTime(2001, 06, 12)
                    },
                    new Book
                    {
                        Title = "Herland",
                        GenreId = 2,
                        PageCount = 250,
                        AuthorId = 2,
                        PublishDate = new DateTime(2010, 05, 23)
                    },
                    new Book
                    {
                        Title = "Dune",
                        GenreId = 2,
                        PageCount = 540,
                        AuthorId = 3,
                        PublishDate = new DateTime(2001, 12, 21)
                    },
                    new Book
                    {
                        Title = "God Of River",
                        GenreId = 3,
                        PageCount = 440,
                        AuthorId = 4,
                        PublishDate = new DateTime(1997, 12, 21)
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
