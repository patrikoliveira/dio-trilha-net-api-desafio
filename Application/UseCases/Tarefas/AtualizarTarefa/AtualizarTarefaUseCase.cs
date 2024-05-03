using AutoMapper;
using TrilhaApiDesafio.Application.UseCases.Tarefas.ObterTarefaPorId;
using TrilhaApiDesafio.Domain.Entities;
using TrilhaApiDesafio.Domain.Repositories;
using TrilhaApiDesafio.Domain.Repositories.Tarefa;
using TrilhaApiDesafio.Shared.Comunication.Responses;
using TrilhaApiDesafio.Shared.Exceptions.ExceptionsBase;

namespace TrilhaApiDesafio.Application.UseCases.Tarefas.AtualizarTarefa
{
    public class AtualizarTarefaUseCase : IAtualizarTarefaUseCase
    {
        private readonly ITarefaWriteOnlyRepository writeOnlyRepository;
        private readonly ITarefaReadOnlyRepository readOnlyRepository;
        private readonly AtualizarTarefaValidator validator;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public AtualizarTarefaUseCase(ITarefaWriteOnlyRepository writeOnlyRepository, ITarefaReadOnlyRepository readOnlyRepository, IUnitOfWork unitOfWork, IMapper mapper, AtualizarTarefaValidator validator)
        {
            this.writeOnlyRepository = writeOnlyRepository;
            this.readOnlyRepository = readOnlyRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.validator = validator;
        }

        public async Task Execute(int id, AtualizarTarefaRequest request)
        {
            var tarefa = await readOnlyRepository.GetById(id);

            Validate(tarefa, request);

            //var tarefaToUpdate = mapper.Map<Tarefa>(request);
            //tarefaToUpdate.Id = id;

            mapper.Map(request, tarefa);

            writeOnlyRepository.Update(tarefa);
            await unitOfWork.Commit();
        }

        private void Validate(Tarefa tarefa, AtualizarTarefaRequest request)
        {
            if (tarefa is null)
            {
                throw new EntityNotFoundException(new List<string>()
                {
                    $"Tarefa não encontrada na base de dados"
                });
            }

            var resultado = validator.Validate(request);

            if (!resultado.IsValid)
            {
                var errorMessages = resultado.Errors.Select(e => e.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}

