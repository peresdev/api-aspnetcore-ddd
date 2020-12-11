using MercadoEletronico.Domain.Interfaces;
using MercadoEletronico.Infra.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace MercadoEletronico.Infra.CrossCutting.InversionOfControl
{
    public static class SqliteRepositoryDependency
    {
        public static void AddSqliteRepositoryDependency(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryPedido, PedidoRepository>();
        }
    }
}
