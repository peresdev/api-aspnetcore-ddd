using MercadoEletronico.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aurora.Infra.Data.Mapping
{
    public class PedidoMap : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("Pedido");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.CodigoPedido)
                .HasColumnName("Pedido");

            builder
                .HasMany(prop => prop.Itens)
                .WithOne();
        }
    }
}