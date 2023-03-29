using HairManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace HairManager.Infra.AcessoRepositories;

public class HairManagerContext : DbContext
{
    public HairManagerContext(DbContextOptions<HairManagerContext> options) : base(options) { }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Funcionario> Funcionarios { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
