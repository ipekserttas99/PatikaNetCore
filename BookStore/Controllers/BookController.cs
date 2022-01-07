using BookStore.BookOperations.CreateBook;
using BookStore.BookOperations.GetBooks;
using BookStore.BookOperations.UpdateBook;
using BookStore.DBOperations;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using static BookStore.BookOperations.CreateBook.CreateBookCommand;
using static BookStore.BookOperations.UpdateBook.UpdateBookCommand;

namespace BookStore.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        //değiştirilmesini istemiyorum bi kere constructorda set edilsin ve değiştirilemesin
        // inject ettiğimiz için kurucu metotla bu yüzden private kullandık
        public BookController(BookStoreDbContext context)
        {
            _context = context;
        }


        //private static List<Book> BookList = new List<Book>()
        //{
        //    new Book
        //    {
        //        id=1,
        //        Title="Lean Startup",
        //        GenreId=1,
        //        PageCount=200,
        //        PublishDate=new DateTime(2001,06,12)
        //    },
        //    new Book
        //    {
        //        id=2,
        //        Title="Herland",
        //        GenreId=2,
        //        PageCount=250,
        //        PublishDate=new DateTime(2010,05,23)
        //    },
        //    new Book
        //    {
        //        id=3,
        //        Title="Dune",
        //        GenreId=2,
        //        PageCount=540,
        //        PublishDate=new DateTime(2001,12,21)
        //    }
        //};

        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery query = new GetBooksQuery(_context);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            GetBookByIdQuery query = new GetBookByIdQuery(_context);
            var result = query.Handle(id);
            return Ok(result);
        }

        

        //POST
        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {
            CreateBookCommand command = new CreateBookCommand(_context);
            try
            {
                command.Model = newBook;
                command.Handle();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok();
        }

        //PUT
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updatedBook)
        {
            UpdateBookCommand command = new UpdateBookCommand(_context);
            try
            {
                command.Model = updatedBook;
                command.Handle(id, updatedBook);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok(updatedBook);
        }

        //DELETE
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = _context.Books.SingleOrDefault(x => x.Id == id);
            if (book is null)
                return BadRequest();


            _context.Books.Remove(book);
            _context.SaveChanges();
            return Ok();
        }

    }
}
