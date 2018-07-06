using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.IdentityModel.Tokens;
using MySql.Data.MySqlClient;
using Base.Application;
using Base.Domain;
using Base.Persistence;
using Base.Infrastructure;

namespace Base.Service
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)     
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
            .AddEnvironmentVariables();

            Configuration = builder.Build();   
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", 
                new Info { 
                    Title = "API Template", 
                    Version = "v1",
                    Description = "Template para utilizar nos servicos de Back-End",
                    TermsOfService = "None",
                    Contact = new Contact { Name = "Services 4U", Email = "suporte@services4u.com.br", Url = "http://www.services4u.com.br"}
                });
            });

            services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme = "JwtBearer";
                options.DefaultChallengeScheme = "JwtBearer";
            }).AddJwtBearer("JwtBearer", options => {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                    ValidAudience = "The name of audience",
                    ValidateIssuer = false,
                    ValidIssuer = "The name of the issuer",

                    ValidateIssuerSigningKey = true,
                    //Palavra chave
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("@S3rv1c354uServices4U")),
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(5)
                };
            });

            services.AddCors();
            //ou
            //services.AddCors(options =>
            //{
            //    options.AddPolicy("AllowSpecificOrigin",
            //        builder => builder.WithOrigins("http://example.com"));
            //});

            //Lendo chaves no arquivo de configuracoes
            services.AddOptions();
            services.Configure<KeysConfig>(Configuration);

            //Descomentar se utilizar a ConnectionString do arquivo appsettings.json
            //Func<IServiceProvider, MySqlConnection> Connect = a => new MySqlConnection(Configuration.GetConnectionString("DefaultConnection"));
            //services.AddScoped(Connect);
            services.AddScoped(typeof(IConnection), typeof(Connection));
            services.AddScoped(typeof(ISampleRepository), typeof(SampleRepository));
            services.AddScoped(typeof(ISampleManager), typeof(SampleManager));
            services.AddSingleton<IConfiguration>(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseCors(
                options => options.WithOrigins("http://example.com")
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials()
            );
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Template V1");
            });
        }
    }
}
