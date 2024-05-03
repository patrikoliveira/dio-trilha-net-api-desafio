using AutoMapper;
using TrilhaApiDesafio.Domain.Repositories.Tarefa;
using TrilhaApiDesafio.Shared.Comunication.Responses;
using TrilhaApiDesafio.Shared.Exceptions.ExceptionsBase;

namespace TrilhaApiDesafio.Application.UseCases.Tarefas.ObterTarefaPorId
{
    public class ObterTarefaPorId : IObterTarefaPorId
    {
        private readonly ITarefaReadOnlyRepository readOnlyRepository;
        private readonly IMapper mapper;

        public ObterTarefaPorId(ITarefaReadOnlyRepository readOnlyRepository, IMapper mapper)
        {
            this.readOnlyRepository = readOnlyRepository;
            this.mapper = mapper;
        }

        public async Task<RespostaTarefaJson> Execute(int id)
        {
            var tarefa = await readOnlyRepository.GetById(id) ?? throw new EntityNotFoundException(new List<string>()
                {
                    $"Tarefa de id: {id} não encontrada na base de dados"
                });

            return mapper.Map<RespostaTarefaJson>(tarefa);
        }
    }
}

