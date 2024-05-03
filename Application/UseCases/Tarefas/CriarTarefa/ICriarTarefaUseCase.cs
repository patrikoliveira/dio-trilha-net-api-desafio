using TrilhaApiDesafio.Shared.Comunication.Responses;

namespace TrilhaApiDesafio.Application.UseCases.Tarefas.CriarTarefa
{
    public interface ICriarTarefaUseCase
    {
        public Task<RespostaTarefaJson> Execute(CriarTarefaRequest request);
    }
}

