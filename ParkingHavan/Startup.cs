using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ParkingHavan.CrossCutting.Ioc;

namespace ParkingHavan
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            //services.AddApiVersioning(setup =>
            //{
            //    setup.DefaultApiVersion = new ApiVersion(1, 0);
            //    setup.AssumeDefaultVersionWhenUnspecified = true;
            //    setup.ReportApiVersions = true;
            //});

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ParkingHavan", Version = "v1" });
            });

            //services.AddApplicationContext(Configuration.GetConnectionString("ParkingHavan"));
            services.AddApplicationContext(Configuration.GetValue<string>("ConnectionStrings:ParkingHavan"));
            services.AddApplicationServicesCollentions();

            MapperConfiguration mapperConfiguration = new(mapperConfig =>
            {
                mapperConfig.AddMaps(new[] { "ParkingHavan.Service" });
            });

            services.AddSingleton(mapperConfiguration.CreateMapper());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ParkingHavan v1"));
            }

            app.UseRouting();

            app.UseCors(builder => builder
              .AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
