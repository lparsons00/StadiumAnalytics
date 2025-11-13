using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StadiumAnalytics.StadiumAnalytics.Application.Services;
using StadiumAnalytics.StadiumAnalytics.Domain.Repositories;
using StadiumAnalytics.StadiumAnalytics.Infrastructure.Data;
using StadiumAnalytics.StadiumAnalytics.Infrastructure.Repositories;

namespace StadiumAnalytics.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Database
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));

            // Repositories
            services.AddScoped<IGateEventRepository, GateEventRepository>();

            // Services
            services.AddScoped<IAnalyticsService, AnalyticsService>();

            return services;
        }
    }
}