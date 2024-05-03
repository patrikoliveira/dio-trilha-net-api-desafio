using TrilhaApiDesafio.Shared.Comunication.Responses;

namespace TrilhaApiDesafio.Application.UseCases.Tarefas.ObterTarefaPorId
{
    public interface IObterTarefaPorId
    {
        public Task<RespostaTarefaJson> Execute(int id);
    }
}

