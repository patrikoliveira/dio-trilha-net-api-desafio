using TrilhaApiDesafio.Shared.Comunication.Responses;

namespace TrilhaApiDesafio.Application.UseCases.Tarefas.ObterTarefaPorTitulo
{
    public interface IObterTarefasPorTitulo
    {
        public Task<IList<RespostaTarefaJson>> Execute(string titulo);
    }
}

