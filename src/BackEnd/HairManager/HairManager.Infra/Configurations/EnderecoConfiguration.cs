using HairManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HairManager.Infra.Configurations;
public class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
{
    public void Configure(EntityTypeBuilder<Endereco> builder)
    {
        builder.ToTable("Enderecos");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Rua).IsRequired().HasMaxLength(200);
        builder.Property(e => e.Numero).IsRequired().HasMaxLength(10);
        builder.Property(e => e.Complemento).HasMaxLength(200);
        builder.Property(e => e.Bairro).IsRequired().HasMaxLength(100);
        builder.Property(e => e.Cidade).IsRequired().HasMaxLength(100);
        builder.Property(e => e.Estado).IsRequired().HasConversion(typeof(string));
        builder.Property(e => e.Pais).IsRequired().HasMaxLength(50);
    }
}
