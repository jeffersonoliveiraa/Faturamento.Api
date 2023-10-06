using Faturamento.Domain.Entities.v1;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Faturamento.Infra.Data.Mapping.v1;

public class FaturamentosMap : IEntityTypeConfiguration<Faturamentos>
{
    public void Configure(EntityTypeBuilder<Faturamentos> builder)
    {
        builder.ToTable("Faturamentos", "dbo");

        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id).HasColumnName("Id");
        builder.Property(u => u.PedidoId).HasColumnName("PedidoId");
        builder.Property(u => u.NomeCliente).HasColumnName("NomeCliente");
        builder.Property(u => u.ValorTotalPedido).HasColumnName("ValorTotalPedido");
    }
}
