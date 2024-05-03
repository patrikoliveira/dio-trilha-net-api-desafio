using TrilhaApiDesafio.Shared.Comunication.Responses;

namespace TrilhaApiDesafio.Application.UseCases.Tarefas.AtualizarTarefa
{
    public interface IAtualizarTarefaUseCase
    {
        public Task Execute(int id, AtualizarTarefaRequest request);
    }
}

