using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.IO;
using Microsoft.IdentityModel.Tokens;

namespace Senai.Senaitur.WebApi.DataBaseFirst
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Documentação EF Core
            // https://docs.microsoft.com/pt-br/ef/core/managing-schemas/scaffolding

            services
                // Adiciona o MVC ao projeto
                .AddMvc()

                // Adiciona as opções do json 
                .AddJsonOptions(options => {
                    // Ignora valores nulos ao fazer junções nas consultas
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                    // Ignora os loopings nas consultas
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                })

                // Define a versão do .NET Core
                .SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_1);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Senai.Senatur.WebApi", Version = "v1" });


            });

            services
                // Define a forma de autenticação
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = "JwtBearer";
                    options.DefaultChallengeScheme = "JwtBearer";
                })

                // Define os parâmetros de validação do token
                .AddJwtBearer("JwtBearer", options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        // Quem está solicitando
                        ValidateIssuer = true,

                        // Quem está validando
                        ValidateAudience = true,

                        // Definindo o tempo de expiração
                        ValidateLifetime = true,

                        // Forma de criptografia
                        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("senatur-chave-autenticacao")),

                        // Tempo de expiração do token
                        ClockSkew = TimeSpan.FromMinutes(30),

                        // Nome da issuer, de onde está vindo
                        ValidIssuer = "Senatur.WebApi",

                        // Nome da audience, de onde está vindo
                        ValidAudience = "Senatur.WebApi"
                    };
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Senai.Senatur.WebApi");
            });

            // Habilita o uso de autenticação
            app.UseAuthentication();

            // Define o uso do MVC
            app.UseMvc();
        }
    }
}
