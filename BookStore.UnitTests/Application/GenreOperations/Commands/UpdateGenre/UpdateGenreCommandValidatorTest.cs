using BookStore.Application.GenreOperations.Commands.UpdateGenre;
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
    public class UpdateGenreCommandValidatorTest : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("az")]
        [InlineData("A")]
        [InlineData("")]

        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string name)
        {
            
            UpdateGenreCommand cmd = new UpdateGenreCommand(null, null);
            cmd.Model = new UpdateGenreModel()
            {
                Name=name
            };

            
            UpdateGenreCommandValidator validator = new UpdateGenreCommandValidator();
            var result = validator.Validate(cmd);

            
            result.Errors.Count.Should().BeGreaterThanOrEqualTo(0);
        }

        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
        {
            UpdateGenreCommand command = new UpdateGenreCommand(null, null);
            command.Model = new UpdateGenreModel()
            {
                Name="Action And Adventure"
            };

            UpdateGenreCommandValidator validator = new UpdateGenreCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThanOrEqualTo(0);
        }
    }
}
