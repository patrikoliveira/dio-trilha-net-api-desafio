using AutoMapper;
using TrilhaApiDesafio.Domain.Repositories.Tarefa;
using TrilhaApiDesafio.Shared.Comunication.Responses;

namespace TrilhaApiDesafio.Application.UseCases.Tarefas.ObterTarefaPorTitulo
{
    public class ObterTarefasPorTitulo : IObterTarefasPorTitulo
    {
        private readonly ITarefaReadOnlyRepository readOnlyRepository;
        private readonly IMapper mapper;

        public ObterTarefasPorTitulo(ITarefaReadOnlyRepository readOnlyRepository, IMapper mapper)
        {
            this.readOnlyRepository = readOnlyRepository;
            this.mapper = mapper;
        }

        public async Task<IList<RespostaTarefaJson>> Execute(string titulo)
        {
            var tarefas = await readOnlyRepository.GetByTitulo(titulo);

            return mapper.Map<IList<RespostaTarefaJson>>(tarefas);
        }
    }
}

