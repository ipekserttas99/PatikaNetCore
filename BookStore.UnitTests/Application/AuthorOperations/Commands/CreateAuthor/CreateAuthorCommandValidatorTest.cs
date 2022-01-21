using BookStore.Application.AuthorOperations.Commands.CreateAuthor;
using BookStore.UnitTests.TestSetup;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static BookStore.Application.AuthorOperations.Commands.CreateAuthor.CreateAuthorCommand;

namespace BookStore.UnitTests.Application.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommandValidatorTest : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("","az",1)]
        [InlineData("Ruhigen","nnn", 0)]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string name, string surname, int bookId)
        {
            CreateAuthorCommand cmd = new CreateAuthorCommand(null, null);
            cmd.Model = new CreateAuthorModel()
            {
                Name = name,
                Surname=surname,
                BookId=bookId
            };

            CreateAuthorCommandValidator validations = new CreateAuthorCommandValidator();
            var result = validations.Validate(cmd);

            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
        {
            CreateAuthorCommand command = new CreateAuthorCommand(null, null);
            command.Model = new CreateAuthorModel()
            {
                Name = "Ahmet",
                Surname="Hakan",
                DateOfBirth=new DateTime(1986,01,01),
                BookId=1
            };

            CreateAuthorCommandValidator validator = new CreateAuthorCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThanOrEqualTo(0);
        }

        [Fact]
        public void WhenDateTimeEqualNowIsGiven_Validator_ShouldBeReturnError()
        {
            CreateAuthorCommand command = new CreateAuthorCommand(null, null);
            command.Model = new CreateAuthorModel()
            {
                Name = "Ahmet",
                Surname = "Hakan",
                DateOfBirth = DateTime.Now.Date,
                BookId = 1
            };

            CreateAuthorCommandValidator validator = new CreateAuthorCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}
