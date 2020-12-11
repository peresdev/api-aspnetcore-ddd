using MercadoEletronico.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aurora.Infra.Data.Mapping
{
    public class ItemMap : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable("Item");

            builder.HasKey(prop => prop.Id);

            builder
                .HasOne(prop => prop.Pedido)
                .WithMany(prop => prop.Itens)
                .HasForeignKey(prop => prop.PedidoId);
        }
    }
}