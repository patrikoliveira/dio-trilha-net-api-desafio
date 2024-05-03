using TrilhaApiDesafio.Domain.Entities;
using TrilhaApiDesafio.Shared.Comunication.Responses;

namespace TrilhaApiDesafio.Application.UseCases.Tarefas.ObterTarefaPorStatus
{
    public interface IObterTarefasPorStatus
    {
        public Task<IList<RespostaTarefaJson>> Execute(EnumStatusTarefa statusTarefa);
    }
}

