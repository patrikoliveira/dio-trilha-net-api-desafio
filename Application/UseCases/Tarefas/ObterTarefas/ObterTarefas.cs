using AutoMapper;
using TrilhaApiDesafio.Domain.Repositories.Tarefa;
using TrilhaApiDesafio.Shared.Comunication.Responses;

namespace TrilhaApiDesafio.Application.UseCases.Tarefas.ObterTarefas
{
    public class ObterTarefas : IObterTarefas
    {
        private readonly ITarefaReadOnlyRepository readOnlyRepository;
        private readonly IMapper mapper;

        public ObterTarefas(ITarefaReadOnlyRepository readOnlyRepository, IMapper mapper)
        {
            this.readOnlyRepository = readOnlyRepository;
            this.mapper = mapper;
        }

        public async Task<IList<RespostaTarefaJson>> Execute()
        {
            var tarefas = await readOnlyRepository.GetAll();
            return mapper.Map<IList<RespostaTarefaJson>>(tarefas);
        }
    }
}

