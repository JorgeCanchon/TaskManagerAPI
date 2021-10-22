using Microsoft.Extensions.DependencyInjection;
using TaskManager.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TaskManager.Infraestructure.Data.EntityFrameworkSQL;

namespace TaskManager.Infraestructure.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }

        public static void ConfigureMySqlServerDBContext(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<RepositoryContextSqlServer>(
                   options => options.UseSqlServer(config.GetConnectionString("SqlServerDBContext"), npgsqlOptions => {
                       npgsqlOptions.CommandTimeout(60);
                   }),
                   ServiceLifetime.Transient
               );
        }
    }
}
