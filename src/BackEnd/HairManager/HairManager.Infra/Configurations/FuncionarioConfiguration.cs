using HairManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HairManager.Infra.Configurations;
public class FuncionarioConfiguration : IEntityTypeConfiguration<Funcionario>
{
    public void Configure(EntityTypeBuilder<Funcionario> builder)
    {
        builder.ToTable("Funcionarios");

        builder.HasKey(f => f.Id);

        builder.Property(f => f.Nome).IsRequired().HasMaxLength(100);
        builder.Property(f => f.Telefone).IsRequired().HasMaxLength(50);
        builder.Property(f => f.DataNascimento).IsRequired();
        builder.Property(f => f.Nacionalidade).IsRequired().HasMaxLength(50);
        builder.Property(f => f.CTPSNumero).IsRequired().HasMaxLength(50);
        builder.Property(f => f.CTPSSerie).IsRequired().HasMaxLength(50);
        builder.Property(f => f.CPF).IsRequired().HasMaxLength(20);
        builder.Property(f => f.RG).IsRequired().HasMaxLength(20);
        builder.Property(f => f.PIS).IsRequired().HasMaxLength(20);
        builder.Property(f => f.Reservista).IsRequired().HasMaxLength(20);
        builder.Property(f => f.Cargo).IsRequired().HasMaxLength(50);
        builder.Property(f => f.Salario).IsRequired().HasPrecision(6,2);
        builder.Property(f => f.EstadoCivil).IsRequired().HasConversion(typeof(string));
        builder.Property(f => f.DataAdmissao).IsRequired();
        builder.Property(f => f.StatusFuncionario).IsRequired().HasConversion(typeof(string));
        builder.Property(f => f.VencimentoFerias).IsRequired();   
    }
}
