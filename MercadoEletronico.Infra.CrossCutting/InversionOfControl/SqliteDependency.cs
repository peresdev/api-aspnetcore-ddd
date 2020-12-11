using MercadoEletronico.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MercadoEletronico.Infra.CrossCutting.InversionOfControl
{
    public static class SqliteDependency
    {
        public static void AddSqliteDependency(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SqliteContext>(options =>
            {
                options.UseSqlite(configuration["Database:Sqlite:ConnectionString"]);
            });
        }
    }
}
