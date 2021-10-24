using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TodoApi.Domain.Repositories;
using TodoApi.Infrastructure.Data.Context;
using TodoApi.Infrastructure.Data.Repositories;

namespace TodoApi.Application.Configurations
{
    public static class ConfigureCoreServices
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<TodoContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("Default")));
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            return services;
        }
    }
}
