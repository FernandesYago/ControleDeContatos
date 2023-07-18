using ControleDeContatos.Data;
using ControleDeContatos.Views.Repositorio;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ControleDeContatos
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
           services.AddControllersWithViews();
            services.AddEntityFrameworkSqlServer()
                .AddDbContext<BancoContext>(o=> o.UseSqlServer(Configuration.GetConnectionString("DataBase")));
            services.AddScoped<IContatoRepositorio, ContatoRepositorio>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configurações de ambiente, middlewares, etc.

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
