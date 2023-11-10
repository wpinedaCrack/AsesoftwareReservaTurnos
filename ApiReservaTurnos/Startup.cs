using ApiReservaTurnos.Domain.IRepositories;
using ApiReservaTurnos.Domain.IServices;
using ApiReservaTurnos.Persistencia.Context;
using ApiReservaTurnos.Persistencia.Repositories;
using ApiReservaTurnos.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiReservaTurnos
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
            services.AddDbContext<AplicationDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("Conexion")));
            //// Service
            services.AddScoped<IServicioService, ServicioService>();
            services.AddScoped<IComercioService, ComercioService>();           
            //// Repository
            services.AddScoped<IServicioRepository, ServicioRepository>();
            services.AddScoped<IComercioRepository, ComercioRepository>();
             

            services.AddControllers().AddNewtonsoftJson(options =>///AddNewtonsoftJson configura el error de ciclos por el include y el ThenInclude
                                      options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                                      );

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Mi API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API V1");

                    // Configurar el formato de fecha en Swagger UI
                    c.DefaultModelRendering(ModelRendering.Model);

                    // Esto cambiará el formato de fecha a "dd/MM/yyyy"
                    c.DisplayRequestDuration();
                    c.DisplayOperationId();
                    //c.DisplayOperationCount();
                    c.ShowExtensions();
                });
            }         
          
            app.UseRouting();          
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
