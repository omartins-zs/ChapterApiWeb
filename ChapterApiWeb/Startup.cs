using ChapterApiWeb.Contexts;
using ChapterApiWeb.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace ChapterApiWeb
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

            // Adicionando CORS | Fazendo Junto e seguindo Exemplo da Video Aula do Encontro Remoto 3 - 21/01
            services.AddCors(options =>
            {

                options.AddPolicy("CorsPolicy",
                      builder =>
                      {
                          builder.WithOrigins("http://localhost:3000")
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                      });
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Version = "v1", Title = "Chapter.ApiWeb" });
            });

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "JwtBearer";
                options.DefaultChallengeScheme = "JwtBearer";
            }).AddJwtBearer("JwtBearer", options =>
            {
                // Instanciando Novo Token
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    // Validaçoes
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    // Aonde Configura o Padrao que tem que ser o token
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("chapter-chave-autenticacao")),
                    // Tempo De funcionamento do Token ate Expirar
                    ClockSkew = TimeSpan.FromMinutes(60),
                    // Nome que precisa vim na Validação
                    ValidAudience = "chapterApiWeb",
                    ValidIssuer = "chapterApiWeb"
                };
            });


            services.AddScoped<ChapterContext, ChapterContext>();

            services.AddTransient<LivroRepository, LivroRepository>();

            services.AddTransient<UsuarioRepository, UsuarioRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Chapter.ApiWeb");
                c.RoutePrefix = String.Empty;
            });


            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            // Fazendo Use do Cors
            app.UseCors("CorsPolicy");

            // Fazendo Use do Service de Authentication
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}