using Magma3.NotaFiscal.Domain.Repositories;
using Magma3.NotaFiscal.Infra.Data.Context;
using Magma3.NotaFiscal.Infra.Data.Repositories;
using Magma3.NotaFiscal.Infra.Data.UoW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Magma3.NotaFiscal.Infra.Data
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddPersistence(configuration)
                .AddUnitOfWork()
                .AddRepositories();

            return services;
        }

        private static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("NotaFiscalCs");

            services.AddDbContext<NotaFiscalDbContext>(options =>
            options
                .UseSqlServer(connectionString)
                .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole())));

            // Banco Sqlite para testes
            //services.AddDbContext<NotaFiscalDbContext>(options => options.UseSqlite("Data Source=NotaFiscalDb.db"));

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<INotaFiscalRepository, NotaFiscalRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();

            return services;
        }

        private static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}