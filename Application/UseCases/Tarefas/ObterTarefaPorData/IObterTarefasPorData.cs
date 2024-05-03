using TrilhaApiDesafio.Shared.Comunication.Responses;

namespace TrilhaApiDesafio.Application.UseCases.Tarefas.ObterTarefaPorData
{
    public interface IObterTarefasPorData
    {
        public Task<IList<RespostaTarefaJson>> Execute(DateTime data);
    }
}

