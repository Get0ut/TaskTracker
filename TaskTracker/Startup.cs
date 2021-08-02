using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using TaskTracker.Models;

namespace TaskTracker
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddTransient<IProjectRepository, ProjectRepository>();
            services.AddTransient<ITaskRepository, TaskRepository>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Task Tracker for Timur", Version = "v1" });
                var filePath = Path.Combine(System.AppContext.BaseDirectory, "TaskTracker.xml");
                c.IncludeXmlComments(filePath);
                c.ResolveConflictingActions(GetProjects => GetProjects.First());
            });

            services.AddDbContext<DataContext>
                (d => d.UseSqlServer("Data Source=Localhost;Initial Catalog=TaskTracker;Integrated Security=True"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("v1/swagger.json", "My TaskTracker V1");
            });

            app.UseSwagger();

            app.UseHttpsRedirection();
            app.UseMvc();

        }
    }
}
