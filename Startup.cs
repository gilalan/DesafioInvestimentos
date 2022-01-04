using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioInvestimentos.Data;
using DesafioInvestimentos.Repositories;
using DesafioInvestimentos.Repositories.interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;

namespace DesafioInvestimentos
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
            services.AddControllers();
            //services.AddSingleton<IAcaoRepositorio, AcaoRepositorio>();
            services.AddScoped<IAcaoRepositorio, AcaoRepositorio>();

            //Parte do Mongodb
            services.AddScoped<IDbContext>(sp =>
            {
                return new MongoContext()
                {
                    ConnectionString = Configuration.GetSection("Mongo:ConnectionString").Get<string>(),
                    DataBase = Configuration.GetSection("Mongo:DataBase").Get<string>()
                };
            });
            //services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new Info { Title = "Carteira de Investimentos - API", Version = "v1" });
            //    c.ResolveConflictingActions(x => x.First());
            //    c.AddSecurityDefinition("Bearer", new ApiKeyScheme
            //    {
            //        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
            //        Name = "Authorization",
            //        In = "header",
            //        Type = "apiKey"
            //    });
            //    c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
            //    {
            //        { "Bearer", Enumerable.Empty<string>() },
            //    });
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
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
