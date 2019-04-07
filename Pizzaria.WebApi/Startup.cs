using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using Pizzaria.Domain.Models;
using Pizzaria.Infra.CrossCutting.IOC;
using Pizzaria.Infra.Data.Context;
using Pizzaria.WebApi.Configurations;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Pizzaria.WebApi
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
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddJsonOptions(option =>
                {
                    var resolver = option.SerializerSettings.ContractResolver;
                    if (resolver != null)
                        (resolver as DefaultContractResolver).NamingStrategy = null;
                });

            services.AddAutoMapperSetup();

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Pizzaria WebApi",
                    Description = "Sistema de controle de pedidos de uma pizzaria",
                    Contact = new Contact { Name = "Guilherme Vilatoro Santos", Email = "vilatorog@gmail.com" }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                s.IncludeXmlComments(xmlPath);
            });

            InjectionDependencies.RegisterDependencies(services);

            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            UpdateDatabase(app);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseCors(options => options.WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader());
            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json",
                    "Pizzaria WebApi");
                c.RoutePrefix = string.Empty;
            });
        }

        private static void UpdateDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<PizzariaContext>())
                {
                    context.Database.Migrate();

                    if (context.TamanhosPizza == null || !context.TamanhosPizza.Any())
                    {
                        context.UpdateRange(new List<object>
                        {
                            new TamanhosPizza { Tamanho = "pequena", Valor = 20, Tempo = 15 },
                            new TamanhosPizza { Tamanho = "média", Valor = 30, Tempo = 20 },
                            new TamanhosPizza { Tamanho = "grande", Valor = 40, Tempo = 25 },
                            new SaboresPizza { Sabor = "calabresa", TempoAdicional = 0 },
                            new SaboresPizza { Sabor = "marguerita", TempoAdicional = 0 },
                            new SaboresPizza { Sabor = "portuguesa", TempoAdicional = 5 },
                            new AdicionaisPizza { Adicional = "extra bacon", Valor = 3, Tempo = 0 },
                            new AdicionaisPizza { Adicional = "sem cebola", Valor = 0, Tempo = 0 },
                            new AdicionaisPizza { Adicional = "borda recheada", Valor = 5, Tempo = 5 }
                        });
                        context.SaveChanges();
                    }
                }
            }
        }
    }
}