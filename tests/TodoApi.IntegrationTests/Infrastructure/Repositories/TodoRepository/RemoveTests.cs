using System;
using System.Threading.Tasks;
using TodoApi.Domain.Repositories.Exceptions;
using Xunit;

namespace TodoApi.IntegrationTests.Infrastructure.Repositories.TodoRepository
{
    public class RemoveTests : BaseTests
    {
        public RemoveTests() : base()
        {
        }

        [Fact]
        public async Task WhenGivenNullIdMustThrowArgumentException() =>
           await Assert.ThrowsAsync<ArgumentNullException>(async () => await TodoRepository.RemoveAsync(null));

        [Fact]
        public async Task MustThrowNotFoundExceptionWhenTodoDoesntExist() =>
            await Assert.ThrowsAsync<NotFoundException>(async () => await TodoRepository.RemoveAsync(0));



        [Fact]
        public async Task WhenDeleteTodoAndTryRetrieveItMustThrowNotFoundException()
        {
            await TodoRepository.InsertAsync(Todo);
            await TodoRepository.RemoveAsync(Todo.Id);
            await Assert.ThrowsAsync<NotFoundException>(async () => await TodoRepository.GetByIdAsync(Todo.Id));
        }
    }
}
