using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SistemaFacturacionApi.BI.Config;
using SistemaFacturacionApi.Config;
using SistemaFacturacionApi.Model.Context;
using SistemaFacturacionApi.Model.IoC;
using SistemaFacturacionApi.Services.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaFacturacionApi
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

            #region App Settings
            #endregion

            #region CORS

            services.AddCors(options =>
            {
                options.AddPolicy("MainPolicy",
                      builder =>
                      {
                          builder
                                 .AllowAnyHeader()
                                 .AllowAnyMethod()
                                 .AllowCredentials();

                          //TODO: remove this line for production
                          builder.SetIsOriginAllowed(x => true);
                      });
            });

            #endregion

            #region External Dependencies

            services.AddControllers(mvcOptions =>
                mvcOptions.EnableEndpointRouting = false).configFluentValidation();
            services.AddDbContext<SistemaFacturacionDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });
            services.configAutoMapper();

            #endregion

            #region Api Libraries

             services.ConfigOdata();
             services.ConfigSwagger();

            #endregion

            #region App Registries

            services.AddModelRegistry();
            services.AddServiceRegistry();
            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseAppSwagger();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("MainPolicy");

            app.UseMvc(routeBuilder => routeBuilder.UseAppOData());

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});
        }
    }
}
