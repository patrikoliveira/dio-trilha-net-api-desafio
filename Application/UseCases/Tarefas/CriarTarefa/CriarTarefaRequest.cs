namespace TrilhaApiDesafio.Application.UseCases.Tarefas.CriarTarefa
{
    public class CriarTarefaRequest
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
    }
}

