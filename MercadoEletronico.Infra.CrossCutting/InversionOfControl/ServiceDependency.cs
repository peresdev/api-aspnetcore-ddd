using MercadoEletronico.Domain.Interfaces;
using MercadoEletronico.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MercadoEletronico.Infra.CrossCutting.InversionOfControl
{
    public static class ServiceDependency
    {
        public static void AddServiceDependency(this IServiceCollection services)
        {
            services.AddScoped<IServicePedido, PedidoService>();
        }
    }
}
