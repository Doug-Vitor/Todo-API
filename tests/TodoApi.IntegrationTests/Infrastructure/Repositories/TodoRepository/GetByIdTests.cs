using System;
using System.Threading.Tasks;
using TodoApi.Domain.Entities;
using TodoApi.Domain.Repositories.Exceptions;
using Xunit;

namespace TodoApi.IntegrationTests.Infrastructure.Repositories.TodoRepository
{
    public class GetByIdTests : BaseTests
    {
        public GetByIdTests() : base()
        {
        }

        [Fact]
        public async Task WhenGivenNullIdMustThrowArgumentException() =>
            await Assert.ThrowsAsync<ArgumentNullException>(async () => await TodoRepository.GetByIdAsync(null));

        [Fact]
        public async Task MustThrowNotFoundExceptionWhenTodoDoesntExist() =>
            await Assert.ThrowsAsync<NotFoundException>(async () => await TodoRepository.GetByIdAsync(0));

        [Fact]
        public async Task WhenAddedTodoMustReturnIt()
        {
            await TodoRepository.InsertAsync(Todo);
            Assert.NotNull(await TodoRepository.GetByIdAsync(Todo.Id));
        }
    }
}
