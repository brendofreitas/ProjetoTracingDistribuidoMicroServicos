//using Deposito.Infrastructure.Data;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Design;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.Configuration.Json;
//using Microsoft.Extensions.FileProviders;
//using Microsoft.Extensions.FileProviders.Physical;

//namespace Deposito.Infrastructure.Factories
//{
//    public class DepositoDbContextFactory : IDesignTimeDbContextFactory<DepositoDbContext>
//    {
//        public DepositoDbContext CreateDbContext(string[] args)
//        {
//            var path = Directory.GetCurrentDirectory();
//            // Define o caminho até o appsettings.json do projeto de startup
//            var configuration = new ConfigurationBuilder()
//                .SetBasePath(Directory.GetCurrentDirectory()) // normalmente o diretório do projeto de startup
//                .AddJsonFile("appsettings.json", optional: false)
//                .Build();

//            var optionsBuilder = new DbContextOptionsBuilder<DepositoDbContext>();
//            var connectionString = configuration.GetConnectionString("Deposito");

//            optionsBuilder.UseNpgsql(connectionString);

//            return new DepositoDbContext(optionsBuilder.Options);
//        }
//    }
//}
