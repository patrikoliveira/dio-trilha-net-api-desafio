using Microsoft.EntityFrameworkCore;
using TrilhaApiDesafio.Domain.Repositories;
using TrilhaApiDesafio.Domain.Repositories.Tarefa;
using TrilhaApiDesafio.Infrastructure.DataAccess;
using TrilhaApiDesafio.Infrastructure.DataAccess.Repositories;

namespace TrilhaApiDesafio.Infrastructure
{
    public static class DependencyInjectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
        {
            AddDbContext(services, configuration);
            AddRepositories(services);
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ITarefaWriteOnlyRepository, TarefaRepository>();
            services.AddScoped<ITarefaReadOnlyRepository, TarefaRepository>();
        }

        private static void AddDbContext(IServiceCollection services, ConfigurationManager configuration)
        {
            var connectionString = configuration.GetConnectionString("ConexaoPadrao");

            services.AddDbContext<TrilhaApiDesafioDbContext>(dbContextOptions =>
            {
                dbContextOptions.UseSqlServer(connectionString);
            });
        }
    }
}

