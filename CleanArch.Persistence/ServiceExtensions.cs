using CleanArch.Domain.Interfaces;
using CleanArch.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using CleanArch.Persistence.Repositores;
using CleanArch.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArch.Persistence
{
    public static class ServiceExtensions
    {
        public static void ConfigurePersistenceApp(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Sqlite");
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlite(connectionString));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
