namespace TrilhaApiDesafio.Domain.Repositories
{
    public interface IUnitOfWork
    {
        public Task Commit();
    }
}

