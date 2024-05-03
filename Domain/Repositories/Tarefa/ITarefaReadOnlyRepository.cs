namespace TrilhaApiDesafio.Domain.Repositories.Tarefa
{
    public interface ITarefaReadOnlyRepository
    {
        public Task<Entities.Tarefa> GetById(int id);
        public Task<IList<Entities.Tarefa>> GetAll();
        public Task<IList<Entities.Tarefa>> GetByTitulo(string titulo);
        public Task<IList<Entities.Tarefa>> GetByData(DateTime data);
        public Task<IList<Entities.Tarefa>> GetByStatus(Entities.EnumStatusTarefa status);
    }
}