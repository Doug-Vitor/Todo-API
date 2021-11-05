using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApi.Domain.Entities;
using Xunit;

namespace TodoApi.IntegrationTests.Infrastructure.Repositories.TodoRepository
{
    public class GetAllTests : BaseTests
    {
        public GetAllTests() : base()
        {
        }

        [Fact]
        public async Task WhenAddedTodosMustReturnThem()
        {
            Todo todo1 = new(Todo.Title, Todo.Description, Todo.IsFinished);
            Todo todo2 = new(Todo.Title, Todo.Description, Todo.IsFinished);

            await TodoRepository.InsertAsync(todo1);
            await TodoRepository.InsertAsync(todo2);

            List<Todo> todos = await TodoRepository.GetAll() as List<Todo>;
            Assert.NotEmpty(todos);
            Assert.True(todos.Count > 1);
        }
    }
}
