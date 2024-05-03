using AutoMapper;
using TrilhaApiDesafio.Domain.Entities;
using TrilhaApiDesafio.Domain.Repositories.Tarefa;
using TrilhaApiDesafio.Shared.Comunication.Responses;

namespace TrilhaApiDesafio.Application.UseCases.Tarefas.ObterTarefaPorStatus
{
    public class ObterTarefasPorStatus : IObterTarefasPorStatus
    {
        private readonly ITarefaReadOnlyRepository readOnlyRepository;
        private readonly IMapper mapper;

        public ObterTarefasPorStatus(ITarefaReadOnlyRepository readOnlyRepository, IMapper mapper)
        {
            this.readOnlyRepository = readOnlyRepository;
            this.mapper = mapper;
        }

        public async Task<IList<RespostaTarefaJson>> Execute(EnumStatusTarefa statusTarefa)
        {
            var tarefas = await readOnlyRepository.GetByStatus(statusTarefa);
            return mapper.Map<IList<RespostaTarefaJson>>(tarefas);
        }
    }
}

