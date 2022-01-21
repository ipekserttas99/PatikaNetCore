using BookStore.DBOperations;
using BookStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.UnitTests.TestSetup
{
    public static class Authors
    {
        public static void AddAuthors(this BookStoreDbContext context)
        {
            context.Authors.AddRange(
                    new Author
                    {
                        Name = "William",
                        Surname = "Shakespeare",
                        BookId = 1,
                        DateOfBirth = new DateTime(1564,04,01)
                    },
                    new Author
                    {
                        Name = "George",
                        Surname = "Orwell",
                        BookId = 2,
                        DateOfBirth = new DateTime(1903,06,25)
                    },
                    new Author
                    {
                        Name = "J.K.",
                        Surname = "Rowling",
                        BookId = 3,
                        DateOfBirth = new DateTime(1965,07,31)
                    },
                    new Author
                    {
                        Name = "Wilbur",
                        Surname = "Smith",
                        BookId = 4,
                        DateOfBirth = new DateTime(1933,01,09)
                    }
                 );
        }
    }
}
