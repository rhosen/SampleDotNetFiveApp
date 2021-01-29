using System;
using System.IO;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SampleDotNetFiveApp.Data.Web.StartupExtensions;

namespace SampleDotNetFiveApp.Data.Web
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
            services.AddMvc()
                .AddFluentValidation()
                .AddJsonOptions(options => { options.JsonSerializerOptions.WriteIndented = true; });
            services.AddDbContextPool<ApiContext>(options => options.UseInMemoryDatabase("Hahn"));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "SampleDotNetFiveApp.Web", 
                    Version = "v1"
                });
                var filePath = Path.Combine(AppContext.BaseDirectory, "SampleDotNetFiveApp.xml");
                c.IncludeXmlComments(filePath);
            });
            services.ValidatorCollection(Configuration);
            services.ManagerCollection(Configuration);
            services.RepositoryCollection(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SampleDotNetFiveApp.Web v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
