using TrilhaApiDesafio.Shared.Comunication.Responses;

namespace TrilhaApiDesafio.Application.UseCases.Tarefas.ObterTarefas
{
    public interface IObterTarefas
    {
        public Task<IList<RespostaTarefaJson>> Execute();
    }
}

