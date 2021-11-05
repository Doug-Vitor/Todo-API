using System;
using System.Threading.Tasks;
using TodoApi.Domain.Entities;
using TodoApi.Domain.Repositories.Exceptions;
using Xunit;

namespace TodoApi.IntegrationTests.Infrastructure.Repositories.TodoRepository
{
    public class UpdateTests : BaseTests
    {
        public UpdateTests() : base()
        {
        }

        [Fact]
        public async Task WhenGivenNullIdMustThrowArgumentException() =>
            await Assert.ThrowsAsync<ArgumentNullException>(async () => await TodoRepository.UpdateAsync(null, null));

        [Fact]
        public async Task MustThrowNotFoundExceptionWhenTodoDoesntExist() =>
            await Assert.ThrowsAsync<NotFoundException>(async () => await TodoRepository.UpdateAsync(0, null));
    
        [Fact]
        public async Task MustReturnValidAndEqualFieldsAfterUpdate()
        {
            await TodoRepository.InsertAsync(Todo);

            Todo.Title += "Updated";
            await TodoRepository.UpdateAsync(Todo.Id, Todo);

            Todo retrievedTodo = await TodoRepository.GetByIdAsync(Todo.Id);

            Assert.NotNull(retrievedTodo);
            for (int propertyCount = 0; propertyCount < Todo.GetType().GetProperties().Length; propertyCount++)
                Assert.Equal(Todo.GetType().GetProperties().GetValue(propertyCount), retrievedTodo.GetType().GetProperties().GetValue(propertyCount));
        }
    }
}
