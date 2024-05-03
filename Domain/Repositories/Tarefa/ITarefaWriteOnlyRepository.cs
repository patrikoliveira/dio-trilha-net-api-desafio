namespace TrilhaApiDesafio.Domain.Repositories.Tarefa
{
    public interface ITarefaWriteOnlyRepository
    {
        public Task Add(Entities.Tarefa tarefa);
        public void Update(Entities.Tarefa tarefa);
        public Task Delete(int id);
    }
}