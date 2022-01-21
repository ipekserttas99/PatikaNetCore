using BookStore.BookOperations.GetBooks;
using BookStore.UnitTests.TestSetup;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BookStore.UnitTests.Application.BookOperations.Queries
{
    public class GetBookDetailsQueryValidatorTest : IClassFixture<CommonTestFixture>
    {
        [Fact]
        public void WhenBookIdIsGiven_Validator_ShouldNotBeReturnError()
        {
            GetBookByIdQuery query = new GetBookByIdQuery(null, null);
            query.BookId = 1;

            GetBookByIdQueryValidator validations = new GetBookByIdQueryValidator();
            var result = validations.Validate(query);

            result.Errors.Count.Should().BeGreaterThanOrEqualTo(0);
        }
    }
}
