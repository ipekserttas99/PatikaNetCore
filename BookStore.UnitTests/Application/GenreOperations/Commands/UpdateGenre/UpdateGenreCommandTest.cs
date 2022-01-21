using AutoMapper;
using BookStore.Application.GenreOperations.Commands.UpdateGenre;
using BookStore.DBOperations;
using BookStore.UnitTests.TestSetup;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static BookStore.Application.GenreOperations.Commands.UpdateGenre.UpdateGenreCommand;

namespace BookStore.UnitTests.Application.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommandTest : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public UpdateGenreCommandTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenGenreIsNotExist_InvalidOperationException_ShouldBeReturn()
        {
            
            UpdateGenreCommand command = new UpdateGenreCommand(_context, _mapper);
            UpdateGenreModel model = new UpdateGenreModel() { Name= "Personal Growth" };
            command.Model = model;
            var genre = _context.Genres.SingleOrDefault(x => x.Id == 1);
            if (genre is null)
                FluentActions
                .Invoking(() => command.Handle(model))
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap türü bulunamadı!");
            
        }
        
        }
    }

