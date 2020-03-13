using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendaSis.Application.Services.Generos;
using AgendaSis.Application.Services.Salas;
using AgendaSis.Domain.Interfaces;
using AgendaSis.Infra.Contexto;
using AgendaSis.Infra.Repositorios;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AgendaSis.Web
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
            services
                .AddDbContext<MeuContexto>(
                    opt => opt.UseNpgsql(Configuration["ConnectionStrings:MinhaStringConexao"])
                );

            services.AddScoped<ISalaRepository, SalaRepository>();
            services.AddScoped<ISalaService, SalaService>();

            services.AddScoped<IGeneroRepository, GeneroRepository>();
            services.AddScoped<IGeneroService, GeneroService>();
            //services.AddScoped<IGeneroService, GeneroFakeService>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
