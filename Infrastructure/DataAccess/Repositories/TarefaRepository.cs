using Microsoft.EntityFrameworkCore;
using TrilhaApiDesafio.Domain.Entities;
using TrilhaApiDesafio.Domain.Repositories.Tarefa;

namespace TrilhaApiDesafio.Infrastructure.DataAccess.Repositories
{
    public class TarefaRepository : ITarefaWriteOnlyRepository, ITarefaReadOnlyRepository
    {
        private readonly TrilhaApiDesafioDbContext dbContext;
        public TarefaRepository(TrilhaApiDesafioDbContext dbContext) => this.dbContext = dbContext;

        public async Task Add(Tarefa tarefa) => await this.dbContext.AddAsync(tarefa);

        public async Task Delete(int id)
        {
            var tarefa = await dbContext.Tarefas.FirstAsync(c => c.Id == id);
            dbContext.Tarefas.Remove(tarefa);
        }

        public void Update(Tarefa tarefa) => dbContext.Tarefas.Update(tarefa);

        public async Task<IList<Tarefa>> GetAll() => await dbContext.Tarefas.AsNoTracking().ToListAsync();

        public async Task<IList<Tarefa>> GetByData(DateTime data) => await dbContext.Tarefas.Where(c => c.Data.Date == data.Date).ToListAsync();

        public async Task<Tarefa> GetById(int id) => await dbContext.Tarefas.FirstOrDefaultAsync(c => c.Id == id);

        public async Task<IList<Tarefa>> GetByStatus(EnumStatusTarefa status) => await dbContext.Tarefas.Where(c => c.Status == status).ToListAsync();

        public async Task<IList<Tarefa>> GetByTitulo(string titulo) => await dbContext.Tarefas.Where(c => c.Titulo == titulo).ToListAsync();
    }
}

