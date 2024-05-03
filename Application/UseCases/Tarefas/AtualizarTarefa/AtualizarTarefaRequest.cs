using TrilhaApiDesafio.Domain.Entities;

namespace TrilhaApiDesafio.Application.UseCases.Tarefas.AtualizarTarefa
{
    public class AtualizarTarefaRequest
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public EnumStatusTarefa Status { get; set; }
    }
}

