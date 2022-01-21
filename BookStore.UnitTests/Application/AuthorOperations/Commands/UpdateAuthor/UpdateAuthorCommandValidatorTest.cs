using BookStore.Application.AuthorOperations.Commands.UpdateAuthor;
using BookStore.UnitTests.TestSetup;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static BookStore.Application.AuthorOperations.Commands.UpdateAuthor.UpdateAuthorCommand;

namespace BookStore.UnitTests.Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandValidatorTest : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("az","lll", 1)]
        [InlineData("AZIMSAMA","l", 0)]

        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string name, string surname, int bookId)
        {
            //arrange
            UpdateAuthorCommand cmd = new UpdateAuthorCommand(null, null);
            cmd.Model = new UpdateAuthorModel()
            {
                Name=name,
                Surname=surname,
                BookId=bookId
            };

            //act
            UpdateAuthorCommandValidator validator = new UpdateAuthorCommandValidator();
            var result = validator.Validate(cmd);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
        {
            UpdateAuthorCommand command = new UpdateAuthorCommand(null, null);
            command.Model = new UpdateAuthorModel()
            {
                Name="DKAFJKSFJKSF",
                Surname="DKsmfksnmfksfm",
                BookId=3
            };

            UpdateAuthorCommandValidator validator = new UpdateAuthorCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThanOrEqualTo(0);
        }

        [Fact]
        public void WhenDateTimeEqualNowIsGiven_Validator_ShouldBeReturnError()
        {
            UpdateAuthorCommand command = new UpdateAuthorCommand(null, null);
            command.Model = new UpdateAuthorModel()
            {

                Name = "DKAFJKSFJKSF",
                Surname = "DKsmfksnmfksfm",
                DateOfBirth=DateTime.Now.Date,
                BookId = 3
            };

            UpdateAuthorCommandValidator validator = new UpdateAuthorCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}
