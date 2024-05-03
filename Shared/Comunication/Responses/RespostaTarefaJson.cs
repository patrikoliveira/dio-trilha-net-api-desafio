using TrilhaApiDesafio.Domain.Entities;

namespace TrilhaApiDesafio.Shared.Comunication.Responses
{
    public class RespostaTarefaJson
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public EnumStatusTarefa Status { get; set; }
    }
}

