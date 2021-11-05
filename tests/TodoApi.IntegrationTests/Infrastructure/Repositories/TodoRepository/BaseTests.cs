using Microsoft.EntityFrameworkCore;
using TodoApi.Domain.Entities;
using TodoApi.Infrastructure.Data.Context;
using TodoApi.Infrastructure.Data.Repositories;

namespace TodoApi.IntegrationTests.Infrastructure.Repositories.TodoRepository
{
    public class BaseTests
    {
        protected readonly BaseRepository<Todo> TodoRepository;
        protected Todo Todo = new(nameof(Todo), nameof(Todo), false);

        public BaseTests() => TodoRepository = new BaseRepository<Todo>(new TodoContext(
            new DbContextOptionsBuilder<TodoContext>().UseInMemoryDatabase("ForTests").Options));
    }
}
