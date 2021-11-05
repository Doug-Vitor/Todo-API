using System;
using System.Threading.Tasks;
using Xunit;

namespace TodoApi.IntegrationTests.Infrastructure.Repositories.TodoRepository
{
    public class InsertTests : BaseTests
    {
        public InsertTests() : base()
        {
        }

        [Fact]
        public async Task WhenInsertNullObjectMustThrowArgumentNullException() =>
            await Assert.ThrowsAsync<ArgumentNullException>(async () => await TodoRepository.InsertAsync(null));
    }
}
