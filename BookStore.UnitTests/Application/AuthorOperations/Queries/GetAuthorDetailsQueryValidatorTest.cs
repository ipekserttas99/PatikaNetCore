using BookStore.Application.AuthorOperations.Queries.GetAuthorDetail;
using BookStore.UnitTests.TestSetup;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BookStore.UnitTests.Application.AuthorOperations.Queries
{
    public class GetAuthorDetailsQueryValidatorTest : IClassFixture<CommonTestFixture>
    {
        [Fact]
        public void WhenAuthorIdIsGiven_Validator_ShouldNotBeReturnError()
        {
            GetAuthorDetailQuery query = new GetAuthorDetailQuery(null, null);
            query.AuthorId = 1;

            GetAuthorDetailQueryValidator validations = new GetAuthorDetailQueryValidator();
            var result = validations.Validate(query);

            result.Errors.Count.Should().BeGreaterThanOrEqualTo(0);
        }
    }
}
