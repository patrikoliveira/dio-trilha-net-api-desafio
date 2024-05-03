using TrilhaApiDesafio.Application.Services.AutoMapper;
using TrilhaApiDesafio.Application.UseCases.Tarefas.AtualizarTarefa;
using TrilhaApiDesafio.Application.UseCases.Tarefas.CriarTarefa;
using TrilhaApiDesafio.Application.UseCases.Tarefas.DeletarTarefa;
using TrilhaApiDesafio.Application.UseCases.Tarefas.ObterTarefaPorData;
using TrilhaApiDesafio.Application.UseCases.Tarefas.ObterTarefaPorId;
using TrilhaApiDesafio.Application.UseCases.Tarefas.ObterTarefaPorStatus;
using TrilhaApiDesafio.Application.UseCases.Tarefas.ObterTarefaPorTitulo;
using TrilhaApiDesafio.Application.UseCases.Tarefas.ObterTarefas;

namespace TrilhaApiDesafio.Application
{
    public static class DependencyInjectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            AddValidators(services);
            AddAutoMapper(services);
            AddUseCases(services);
        }

        private static void AddValidators(IServiceCollection services)
        {
            services.AddScoped(opt => new CriarTarefaValidator());
            services.AddScoped(opt => new AtualizarTarefaValidator());
        }

        private static void AddAutoMapper(IServiceCollection service)
        {
            service.AddScoped(option => new AutoMapper.MapperConfiguration(options =>
            {
                options.AddProfile(new AutoMapping());
            }).CreateMapper());
        }

        private static void AddUseCases(IServiceCollection services)
        {
            services.AddScoped<ICriarTarefaUseCase, CriarTarefaUseCase>();
            services.AddScoped<IObterTarefas, ObterTarefas>();
            services.AddScoped<IObterTarefaPorId, ObterTarefaPorId>();
            services.AddScoped<IObterTarefasPorTitulo, ObterTarefasPorTitulo>();
            services.AddScoped<IObterTarefasPorData, ObterTarefasPorData>();
            services.AddScoped<IObterTarefasPorStatus, ObterTarefasPorStatus>();
            services.AddScoped<IDeletarTarefa, DeletarTarefa>();
            services.AddScoped<IAtualizarTarefaUseCase, AtualizarTarefaUseCase>();
        }
    }
}

