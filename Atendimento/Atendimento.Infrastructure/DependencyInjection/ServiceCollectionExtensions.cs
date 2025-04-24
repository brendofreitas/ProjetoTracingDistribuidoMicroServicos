using Atendimento.Domain.Interfaces;
using Atendimento.Infrastructure.Data;
using Atendimento.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Atendimento.Infrastructure.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AtendimentoDbContext>(options =>
                 options.UseNpgsql(connectionString, b => b.MigrationsAssembly("Atendimento.Infrastructure")));

            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();

            return services;
        }
    }
}
