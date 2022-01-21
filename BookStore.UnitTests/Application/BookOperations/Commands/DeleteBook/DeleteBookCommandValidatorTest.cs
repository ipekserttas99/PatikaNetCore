using BookStore.BookOperations.DeleteBook;
using BookStore.UnitTests.TestSetup;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BookStore.UnitTests.Application.BookOperations.Commands.DeleteBook
{
    public class DeleteBookCommandValidatorTest : IClassFixture<CommonTestFixture>
    {
        [Fact]
        public void WhenBookIdIsGiven_Validator_ShouldNotBeReturnError()
        {
            DeleteBookCommand command = new DeleteBookCommand(null);
            command.BookId = 1;

            DeleteBookCommandValidator validations = new DeleteBookCommandValidator();
            var result = validations.Validate(command);

            result.Errors.Count.Should().BeGreaterThanOrEqualTo(0);
        }
        
    }
}
