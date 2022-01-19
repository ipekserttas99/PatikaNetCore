using BookStore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.DBOperations
{
    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options){

        }

        public DbSet<Book> Books { get; set; } //bu context'e book entity'sini ekledik
        public DbSet<Genre> Genres { get; set; }

        public DbSet<Author> Authors { get; set; }
    }
}
