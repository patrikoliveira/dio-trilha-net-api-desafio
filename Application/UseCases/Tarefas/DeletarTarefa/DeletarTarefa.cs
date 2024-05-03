using TrilhaApiDesafio.Application.UseCases.Tarefas.ObterTarefaPorId;
using TrilhaApiDesafio.Domain.Repositories;
using TrilhaApiDesafio.Domain.Repositories.Tarefa;

namespace TrilhaApiDesafio.Application.UseCases.Tarefas.DeletarTarefa
{
    public class DeletarTarefa : IDeletarTarefa
    {
        private readonly ITarefaWriteOnlyRepository writeOnlyRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IObterTarefaPorId obterTarefaPorId;

        public DeletarTarefa(ITarefaWriteOnlyRepository writeOnlyRepository, IUnitOfWork unitOfWork,  IObterTarefaPorId obterTarefaPorId)
        {
            this.writeOnlyRepository = writeOnlyRepository;
            this.unitOfWork = unitOfWork;
            this.obterTarefaPorId = obterTarefaPorId;
        }

        public async Task Execute(int id)
        {
            await obterTarefaPorId.Execute(id);

            await writeOnlyRepository.Delete(id);
            await unitOfWork.Commit();
        }
    }
}

