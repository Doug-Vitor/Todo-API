using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TodoApi.Domain.Entities;

namespace TodoApi.Infrastructure.Data.Context
{
    public class TodoContext : DbContext
    {
        public DbSet<Todo> Todos { get; set; }

        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
