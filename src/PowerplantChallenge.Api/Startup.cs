using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using PowerplantChallenge.Application.Interfaces;
using PowerplantChallenge.Application.Services;

namespace PowerplantChallenge.Api
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IProductionPlanService, ProductionPlanService>();
            services.AddControllers().AddNewtonsoftJson();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApi", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApi v1"));
            app.UseRouting();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}