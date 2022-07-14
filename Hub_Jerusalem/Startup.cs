using AutoMapper;
using BL;
using DL;
using Entity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hub_Jerusalem
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
            services.AddScoped<IUserDL, UserDL>();
            services.AddScoped<IUserBL, UserBL>();

            services.AddScoped<IRoomDL, RoomDL>();
            services.AddScoped<IRoomBL, RoomBL>();

            services.AddScoped<IRoomBookingDL, RoomBookingDL>();
            services.AddScoped<IRoomBookingBL, RoomBookingBL>();

            services.AddScoped<IReportBL, ReportBL>();

            services.AddScoped<IRatingDL, RatingDL>();
            services.AddScoped<IRatingBL, RatingBL>();

            services.AddDbContext<Hub_JerusalemContext>(Options=>Options.UseSqlServer(Configuration.GetConnectionString("HubJerusalem")));
            services.AddAutoMapper(typeof(Startup));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Hub_Jerusalem", Version = "v1" });
            });
            //services.AddResponseCaching();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,ILogger<Startup> logger)
        {
            logger.LogInformation("server is up:)");
            try
            {
                throw new Exception();
            }
            catch(Exception exc)
            {
                logger.LogError(exc.Message);
            }
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hub_Jerusalem v1"));
            }

            //app.UseResponseCaching();

            //app.UseDeveloperExceptionPage();
            app.UseHttpsRedirection();

            app.UseRouting();
            //app.UseRatingMiddleware();

            app.Map("/api", app2 =>
            {
                app2.UseRouting();
                //app2.UseCacheMiddleware();
                //app2.UseErrorMiddleware();

                app2.UseEndpoints(endpoint =>
                {
                    endpoint.MapControllers();
                });
            });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
