using Data.DBContext;
using Data.Implementation;
using Data.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;

namespace TaskManagementApi
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
            services.AddDbContext<TaskManagementDbContext>(options =>
               options.UseSqlServer(
                   Configuration.GetConnectionString("TaskConnectionString")));
            services.AddSwaggerGen();
            services.AddScoped(typeof(IBaseRespository<>),  typeof(BaseRespository<>));
            services.AddScoped<ITaskManagementRepository, TaskManagementRepository>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

          

            app.UseRouting();
            List<string> origins = new List<string> { "http://localhost:4200", "https://localhost:4200", "http://localhost:4300", "http://localhost:4500" };

            app.UseCors(options =>
            {
                options.WithOrigins(origins.ToArray()).AllowAnyMethod().AllowCredentials().AllowAnyHeader().SetIsOriginAllowed((host) => true);
            });

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("v1/swagger.json", "Task Management API (V 1.0)");
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
