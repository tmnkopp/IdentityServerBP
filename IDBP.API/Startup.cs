using IDBP.API.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IDBP.API
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

            //   services.AddAuthentication(options =>
            //   {
            //       options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //       options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //   })
            //   .AddJwtBearer(options =>
            //   {
            //       options.Authority = "http://localhost:5005/"; // base-address of your identityserver 
            //       options.Audience = "IDBP_API"; // name of the API resource
            //       options.RequireHttpsMetadata = false;
            //   });
             services.AddAuthentication("Bearer")
             .AddIdentityServerAuthentication(options =>
             {
                 options.Authority = "http://localhost:5005/"; 
                 options.ApiName = "IDBP_API";
                 options.RequireHttpsMetadata = false;
             });
  
            services.AddDbContext<IDBPContext>(options =>
                 options.UseSqlServer(Configuration.GetConnectionString("default"))
             );
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

            app.UseAuthentication();
            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
