using HairManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HairManager.Infra.AcessoRepositories;

public class HairManagerContext : DbContext
{
    public HairManagerContext(DbContextOptions<HairManagerContext> options) : base(options) { }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Funcionario> Funcionarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(HairManagerContext).Assembly);
    }
}
