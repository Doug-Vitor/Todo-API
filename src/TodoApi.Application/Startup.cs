using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using TodoApi.Application.Configurations;
using TodoApi.Application.Configurations.Mapper;
using TodoApi.Infrastructure.Data.Services;

namespace TodoApi.Application
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration) => Configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);
            
            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "TodoApi.Application", Version = "v1" }));

            services.AddCoreServices(Configuration);
            services.AddMapper();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, SeedingServices seedServices)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                seedServices.SeedDatabase();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TodoApi.Application v1"));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
