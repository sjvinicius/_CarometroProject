using Carometro.Dominio.Handlers.Alunos;
using Carometro.Dominio.Handlers.Autenticacao;
using Carometro.Dominio.Handlers.Usuarios;
using Carometro.Dominio.Repositorios;
using Carometro.Infra.Data.Contexts;
using Carometro.Infra.Data.Repositorios;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Api
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

            services.AddDbContext<CarometroContext>(o => o.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = "Carometro",
                        ValidAudience = "Carometro",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ChaveSecretaCarometroSenai321"))
                    };
                });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Carometro.Api", Version = "v1" });
            });

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                                      .AllowAnyMethod()
                                      .AllowAnyHeader()
                    );
            });

            #region Injeções de Dependência Usuário

            services.AddTransient<LogarHandle, LogarHandle>();
            services.AddTransient<IUsuarioRepositorio, UsuarioRepositorio>();
            services.AddTransient<CriarUsuarioHandle, CriarUsuarioHandle>();
            services.AddTransient<ListarUsuariosHandle, ListarUsuariosHandle>();
            services.AddTransient<ListarAdministradoresHandle, ListarAdministradoresHandle>();
            services.AddTransient<ListarColaboradoresHandle, ListarColaboradoresHandle>();
            services.AddTransient<ExcluirUsuarioHandle, ExcluirUsuarioHandle>();

            #endregion

            #region Injeções de Dependência Aluno

            services.AddTransient<IAlunoRepositorio, AlunoRepositorio>();
            services.AddTransient<CriarAlunoHandle, CriarAlunoHandle>();
            services.AddTransient<ExcluirAlunoHandle, ExcluirAlunoHandle>();
            services.AddTransient<ListarAlunosHandle, ListarAlunosHandle>();

            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Carometro.Api v1"));
            }

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                        Path.Combine(Directory.GetCurrentDirectory(), "Images")),
                RequestPath = "/Images"
            });

            app.UseCors("CorsPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
