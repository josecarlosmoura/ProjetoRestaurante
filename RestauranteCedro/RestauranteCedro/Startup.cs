using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RestauranteCedro.Controllers;
using Swashbuckle.AspNetCore.Swagger;

namespace RestauranteCedro
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<RestauranteCedroContext>(
                opt => opt.UseSqlServer("Server=tcp:moura-srv.database.windows.net,1433;Initial Catalog=bdmoura;Persist Security Info=False;User ID=jmourasi;Password=Leonora@@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"));
            
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info() {Title = "Restaurante Cedro", Version = "v1"});
            });
            
            services.AddMvc();
            
            services.AddScoped<RestauranteCedroContext>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Restaurante Cedro");
            });
            
            app.UseMvc();
        }
        /*public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }*/
    }
}