using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VaccinationCard.Application.Interfaces;
using VaccinationCard.Domain.Interfaces;
using VaccinationCard.Infrastructure.Authentication;
using VaccinationCard.Infrastructure.Persistence;
using VaccinationCard.Infrastructure.Repositories;

namespace VaccinationCard.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // Repositories
            services.AddScoped<IContaRepository, ContaRepository>();

            // Services
            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

            return services;
        }
    }
}
