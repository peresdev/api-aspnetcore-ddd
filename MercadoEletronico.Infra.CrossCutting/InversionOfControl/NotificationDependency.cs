using Infra.Shared.Contexts;
using Microsoft.Extensions.DependencyInjection;

namespace MercadoEletronico.Infra.CrossCutting.InversionOfControl
{
    public static class NotificationDependency
    {
        public static void AddNotificationDependency(this IServiceCollection services)
        {
            services.AddScoped<NotificationContext>();
        }
    }
}
