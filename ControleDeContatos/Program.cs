using ControleDeContatos.Data;
using Microsoft.EntityFrameworkCore;

namespace ControleDeContatos
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
    
            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<BancoContext>
  (options => options.UseMySql("server=localhost; initial catalog=ProjetoDesgraça;uid= root; pwd=",
  Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.33-mysql")));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}