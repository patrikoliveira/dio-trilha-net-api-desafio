using Microsoft.EntityFrameworkCore;
using TrilhaApiDesafio.Domain.Entities;

namespace TrilhaApiDesafio.Infrastructure.DataAccess
{
    public class TrilhaApiDesafioDbContext : DbContext
    {
        public TrilhaApiDesafioDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Tarefa> Tarefas { get; set; }
    }
}

