using FilmesAPI.Infra;
using FilmesAPI.Infra.Repositories.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace FilmesAPI
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
            services.AddDbContext<AppDbContext>(opts => opts.UseLazyLoadingProxies().UseMySQL(Configuration.GetConnectionString("CinemaConnection")));
            services.AddControllers();
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "FilmesAPI", Version = "v1" });
            //});
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddMvc();

            services.AddScoped<Application.Handlers.Interfaces.IFilmeHandler, Application.Handlers.FilmeHandler>();
            services.AddScoped<IFilmeRepository, Infra.Repositories.FilmeRepository>();

            services.AddScoped<Application.Handlers.Interfaces.ISessaoHandler, Application.Handlers.SessaoHandler>();
            services.AddScoped<ISessaoRepository, Infra.Repositories.SessaoRepository>();

            services.AddScoped<Application.Handlers.Interfaces.IGerenteHandler, Application.Handlers.GerenteHandler>();
            services.AddScoped<IGerenteRepository, Infra.Repositories.GerenteRepository>();

            services.AddScoped<Application.Handlers.Interfaces.IEnderecoHandler, Application.Handlers.EnderecoHandler>();
            services.AddScoped<IEnderecoRepository, Infra.Repositories.EnderecoRepository>();

            services.AddScoped<Application.Handlers.Interfaces.ICinemaHandler, Application.Handlers.CinemaHandler>();
            services.AddScoped<ICinemaRepository, Infra.Repositories.CinemaRepository>();

            services.AddScoped<Application.Handlers.Interfaces.IHomeHandler, Application.Handlers.HomeHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseSwagger();
                //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FilmesAPI v1"));
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
