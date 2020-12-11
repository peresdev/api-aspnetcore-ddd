using MercadoEletronico.Infra.CrossCutting.Filter;
using MercadoEletronico.Infra.CrossCutting.InversionOfControl;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MercadoEletronico.Application
{
    public class Startup
    {
        public Startup(IConfiguration configuration) =>
            Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(config =>
            {
                config.EnableEndpointRouting = false;
                config.Filters.Add<NotificationFilter>();
            });
            services.AddSqliteDependency(Configuration);
            services.AddSqliteRepositoryDependency();
            services.AddServiceDependency();
            services.AddSwaggerDependency();
            services.AddNotificationDependency();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseMvc();
            app.UseSwaggerDependency();
        }
    }
}
