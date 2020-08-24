using System;
using AutoMapper;
using IndraApp.API.Models;
using IndraApp.ApplicationCore.Entities;
using IndraApp.ApplicationCore.Interfaces.Repositories;
using IndraApp.ApplicationCore.Interfaces.Services;
using IndraApp.ApplicationCore.Services;
using IndraApp.Infrastructure.Data;
using IndraApp.Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace IndraApp.API
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

            // Adicionando Acesso aos Controllers
            services.AddControllers();

            #region Adicionando Injeção de Dependência nos Services e Repositories

            //Repositories
            services.AddTransient<IRepository<Estudante>, Repository<Estudante>>();
            services.AddTransient<IRepository<Cartao>, Repository<Cartao>>();
            services.AddTransient<IRepository<Curso>, Repository<Curso>>();
            services.AddTransient<IRepository<Pagamento>, Repository<Pagamento>>();
            services.AddTransient<IRepository<Matricula>, Repository<Matricula>>();

            //Services
            services.AddTransient<IEstudanteService, EstudanteService>();
            services.AddTransient<IService<Cartao>, CartaoService>();
            services.AddTransient<IService<Curso>, CursoService>();
            services.AddTransient<IService<Pagamento>, PagamentoService>();
            services.AddTransient<IService<Matricula>, MatriculaService>();

            #endregion

            // Configurando o Doc do Auth do Swagger
            services.AddSwaggerGen(c => {
                
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Plataforma de Cursos",
                        Version = "v1",
                        Description = "Prova de seleção da Indra. Plataforma de Sistema de Cursos",
                        Contact = new OpenApiContact
                        {
                            Name = "Carlos Vamberto A M Filho", 
                            Email = "carlosvamberto@hotmail.com",
                            Url = new Uri("http://www.linkedin.com/in/carlosvamberto")
                        }
                    });
            });

            // Configuração da Injeção de Dependência do Singleton do AutoMapper
            var config = new MapperConfiguration(cfg =>
            {
                
                cfg.CreateMap<Estudante, EstudanteModel>();
                cfg.CreateMap<EstudanteModel, Estudante>();

                cfg.CreateMap<Cartao, CartaoModel>().ReverseMap();
                cfg.CreateMap<CartaoModel, Cartao>().ReverseMap();

                cfg.CreateMap<Curso, CursoModel>().ReverseMap();
                cfg.CreateMap<CursoModel, Curso>().ReverseMap();

                cfg.CreateMap<Pagamento, PagamentoModel>().ReverseMap();
                cfg.CreateMap<PagamentoModel, Pagamento>().ReverseMap();

                cfg.CreateMap<Matricula, MatriculaModel>().ReverseMap();
                cfg.CreateMap<MatriculaModel, Matricula>().ReverseMap();

            });
            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            // Adicionando Contexto do Banco
            services
                .AddDbContext<CursosContext>(
                    opt => opt.UseSqlServer("Server = localhost; Database = CursosDB; Trusted_Connection = True")
                );

            //services
            //    .AddDbContext<CursosContext>(
            //        opt => opt.UseSqlServer(Configuration.GetConnectionString("CursosConnection"))
            //    );


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Plataforma de Cursos V1");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
