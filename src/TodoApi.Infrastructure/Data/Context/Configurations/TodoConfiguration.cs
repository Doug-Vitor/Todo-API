using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoApi.Domain.Entities;

namespace TodoApi.Infrastructure.Data.Context.Configurations
{
    public class TodoConfiguration : IEntityTypeConfiguration<Todo>
    {
        public void Configure(EntityTypeBuilder<Todo> builder)
        {
            builder.HasKey(key => key.Id);
            builder.Property(prop => prop.Title).IsRequired().HasMaxLength(75);
            builder.Property(prop => prop.Description).HasMaxLength(200);
            builder.Property(prop => prop.IsFinished).IsRequired();
            builder.Property(prop => prop.CreatedAt).IsRequired();
        }
    }
}
