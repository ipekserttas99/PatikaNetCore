using BookStore.BookOperations.UpdateBook;
using BookStore.UnitTests.TestSetup;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static BookStore.BookOperations.UpdateBook.UpdateBookCommand;

namespace BookStore.UnitTests.Application.BookOperations.Commands.UpdateBook
{
    public class UpdateBookCommandValidatorTest : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("az", 1)]
        [InlineData("AZIMSAMA", 0)]
        
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string title, int genreId)
        {
            //arrange
            UpdateBookCommand cmd = new UpdateBookCommand(null, null);
            cmd.Model = new UpdateBookModel()
            {
                Title = title,
                GenreId = genreId
            };

            //act
            UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
            var result = validator.Validate(cmd);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
        {
            UpdateBookCommand command = new UpdateBookCommand(null, null);
            command.Model = new UpdateBookModel()
            {
                Title = "Lord Of The Rings",
                GenreId = 1
            };

            UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThanOrEqualTo(0);
        }
    }
}
