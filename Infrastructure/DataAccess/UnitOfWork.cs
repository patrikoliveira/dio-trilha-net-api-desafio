using TrilhaApiDesafio.Domain.Repositories;

namespace TrilhaApiDesafio.Infrastructure.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TrilhaApiDesafioDbContext dbContext;

        public UnitOfWork(TrilhaApiDesafioDbContext dbContext) => this.dbContext = dbContext;

        public async Task Commit() => await this.dbContext.SaveChangesAsync();
    }
}

