using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SimpleCRM.Context;
using SimpleCRM.Models;

namespace SimpleCRM
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Настройка службы подключения к базе данных
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Добавляем поддержку контроллеров с представлениями
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Конфигурация конвейера обработки запросов
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
                name: "manager",
                pattern: "manager",
                defaults: new { controller = "Manager", action = "Login" });

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Products}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
