using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebStore.DAL;
using WebStore.DomainNew.Entities;
using WebStore.Infrastructure;
using WebStore.Infrastructure.Interfaces;
using WebStore.Infrastructure.Services;

namespace WebStore
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();//деклорируем что можем использовать MVC

            services.AddScoped<IProductService, SqlProductService>();

            //добавляет разрешение зависимости. Где встречается интерфейс IEmployeeService он заменится классом EmployeeService 
            //тоесть EmployeeService можно будет заменять любым другим классом 
            services.AddScoped<IEmployeeService, EmployeeService>();

            services.AddDbContext<WebStoreContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //добавление подержка пакета и связываем Core
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<WebStoreContext>()
                .AddDefaultTokenProviders();

            //опции для ввода пароля, логина и тд.
            services.Configure<IdentityOptions>(o =>
                {
                    o.Password.RequiredLength = 3;
                    o.Password.RequireDigit = false;
                    o.Password.RequireLowercase = false;
                    o.Password.RequireUppercase = false;
                    o.Password.RequireNonAlphanumeric = false;
                });

            //Опции работы с кукис
            services.ConfigureApplicationCookie(o =>
                o.Cookie.Expiration = TimeSpan.FromDays(100));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();//нужен для использование файлов в wwwroot
            app.UseAuthentication();//аутонтификация ставится перед статическими файлами чтобы анонимы видели их все что ниже только после аутонтификации
            app.UseMvcWithDefaultRoute();
            //app.UseMiddleware<TokenMiddleware>();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            var helloMessage = Configuration["CustomHelloWorld"];
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync(helloMessage);
            });
        }
    }
}
