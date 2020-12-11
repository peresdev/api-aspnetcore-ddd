using Aurora.Infra.Data.Mapping;
using Flunt.Notifications;
using MercadoEletronico.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection;

namespace MercadoEletronico.Infra.Data.Context
{
    public class SqliteContext : DbContext
    {
        public SqliteContext(DbContextOptions<SqliteContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Pedido> Pedido { get; set; }
        
        public DbSet<Item> Item { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Pedido>(new PedidoMap().Configure);
            modelBuilder.Entity<Item>(new ItemMap().Configure);

            var entites = Assembly
                .Load("MercadoEletronico.Domain")
                .GetTypes()
                .Where(w => w.Namespace == "MercadoEletronico.Domain.Entities" && w.BaseType.BaseType == typeof(Notifiable));

            foreach (var item in entites)
            {
                modelBuilder.Entity(item).Ignore(nameof(Notifiable.Invalid));
                modelBuilder.Entity(item).Ignore(nameof(Notifiable.Valid));
                modelBuilder.Entity(item).Ignore(nameof(Notifiable.Notifications));
            }
        }
    }
}
