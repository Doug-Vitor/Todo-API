using Microsoft.Extensions.DependencyInjection;

namespace TodoApi.Application.Configurations.Mapper
{
    public static class ConfigureMapper
    {
        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup).Assembly);
            return services;
        }
    }
}
