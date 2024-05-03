using AutoMapper;
using TrilhaApiDesafio.Domain.Repositories.Tarefa;
using TrilhaApiDesafio.Shared.Comunication.Responses;

namespace TrilhaApiDesafio.Application.UseCases.Tarefas.ObterTarefaPorData
{
    public class ObterTarefasPorData : IObterTarefasPorData
    {
        private readonly ITarefaReadOnlyRepository readOnlyRepository;
        private readonly IMapper mapper;

        public ObterTarefasPorData(ITarefaReadOnlyRepository readOnlyRepository, IMapper mapper)
        {
            this.readOnlyRepository = readOnlyRepository;
            this.mapper = mapper;
        }

        public async Task<IList<RespostaTarefaJson>> Execute(DateTime data)
        {
            var tarefas = await readOnlyRepository.GetByData(data);

            return mapper.Map<IList<RespostaTarefaJson>>(tarefas);
        }
    }
}

