using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Product.Data;




namespace Api2{
    public class Startup{
        public Startup(IConfiguration configuration)
        {
            Configuration= configuration;
        }
        public IConfiguration Configuration{get;}

        public void ConfigureServices(IServiceCollection services)
        
        {
            services.AddApplicationInsightsTelemetry();
            services.AddDbContext<DataContext>(options=>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddControllers();
            services.AddSwaggerGen(c=>
           {
               c.SwaggerDoc("v1", new OpenApiInfo{ Title="Api2",Version="v2"});
           });

        }

        public void Configure (IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (true)
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c=>c.SwaggerEndpoint("/swagger/v1/swagger.json","Api2 v1"));
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            
        }
        
    }
}