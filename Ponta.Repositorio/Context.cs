using Microsoft.EntityFrameworkCore;
using Ponta.Dominio;

namespace Ponta.Repositorio;

public class Context : DbContext, IUnitOfWork
{
    public Context(DbContextOptions<Context> options)
        : base(options)
    { }

    public DbSet<Usuario> Usuario { get; set; }
    public DbSet<Tarefa> Tarefa { get; set; }

    public void Save()
    {
        base.SaveChanges();
    }

}
