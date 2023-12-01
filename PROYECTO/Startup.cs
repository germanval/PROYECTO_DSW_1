using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PROYECTO.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PROYECTO
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddDbContext<ProductoContext>(option =>
            option.UseSqlServer(Configuration.GetConnectionString("ToyotaDB"),
            ef => ef.MigrationsAssembly(typeof(ProductoContext).Assembly.FullName)));
            services.AddCors(options =>
            {
                options.AddPolicy("AllowFrontend", builder =>
                {
                    builder.WithOrigins("http://127.0.0.1:5500")  // Reemplaza con la URL de tu aplicación frontend
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials();
                });
            });
            services.AddControllers();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseFileServer(new FileServerOptions
            {
                FileProvider=new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(),"Vista")),
                RequestPath="/vista",
                EnableDefaultFiles=true
                    
            });
            app.UseFileServer(new FileServerOptions
            {
                FileProvider = new PhysicalFileProvider(
                   Path.Combine(Directory.GetCurrentDirectory(), "Css")),
                RequestPath = "/Css",
                EnableDefaultFiles = true

            });
            app.UseFileServer(new FileServerOptions
            {
                FileProvider = new PhysicalFileProvider(
                   Path.Combine(Directory.GetCurrentDirectory(), "Js")),
                RequestPath = "/Js",
                EnableDefaultFiles = true

            });
            app.UseFileServer(new FileServerOptions
            {
                FileProvider = new PhysicalFileProvider(
                Path.Combine(Directory.GetCurrentDirectory(), "Gif")),
                RequestPath = "/Gif",
                EnableDefaultFiles = true

            });
            app.UseFileServer(new FileServerOptions
            {
                FileProvider = new PhysicalFileProvider(
                Path.Combine(Directory.GetCurrentDirectory(), "Imagenes")),
                RequestPath = "/Imagenes",
                EnableDefaultFiles = true

            });
            app.UseHttpsRedirection();

            app.UseCors("AllowFrontend");

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
