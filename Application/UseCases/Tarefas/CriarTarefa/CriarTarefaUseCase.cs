using AutoMapper;
using TrilhaApiDesafio.Domain.Entities;
using TrilhaApiDesafio.Domain.Repositories;
using TrilhaApiDesafio.Domain.Repositories.Tarefa;
using TrilhaApiDesafio.Shared.Comunication.Responses;
using TrilhaApiDesafio.Shared.Exceptions.ExceptionsBase;

namespace TrilhaApiDesafio.Application.UseCases.Tarefas.CriarTarefa
{
    public class CriarTarefaUseCase : ICriarTarefaUseCase
    {
        private readonly ITarefaWriteOnlyRepository writeOnlyRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly CriarTarefaValidator validator;
        private readonly IMapper mapper;

        public CriarTarefaUseCase(ITarefaWriteOnlyRepository writeOnlyRepository, IUnitOfWork unitOfWork, CriarTarefaValidator validator, IMapper mapper)
        {
            this.writeOnlyRepository = writeOnlyRepository;
            this.unitOfWork = unitOfWork;
            this.validator = validator;
            this.mapper = mapper;
        }

        public async Task<RespostaTarefaJson> Execute(CriarTarefaRequest request)
        {
            Validate(request);

            var tarefa = mapper.Map<Tarefa>(request);

            await writeOnlyRepository.Add(tarefa);
            await unitOfWork.Commit();

            return mapper.Map<RespostaTarefaJson>(tarefa);
        }

        private void Validate(CriarTarefaRequest request)
        {
            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}

