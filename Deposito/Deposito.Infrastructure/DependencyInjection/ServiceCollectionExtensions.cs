using Deposito.Application.Contracts;
using Deposito.Domain.Interfaces;
using Deposito.Infrastructure.Data;
using Deposito.Infrastructure.ExternalServices.Deposito;
using Deposito.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;





namespace Deposito.Infrastructure.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<DepositoDbContext>(options =>
                 options.UseNpgsql(connectionString, b => b.MigrationsAssembly("Deposito.Infrastructure")));

            services.AddScoped<IProdutoRepository, ProdutoRepository>();
           


            return services;
        }
    }
}
