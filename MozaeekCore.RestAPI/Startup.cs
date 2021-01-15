using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MozaeekCore.ApplicationService.Contract;
using MozaeekCore.Persistense.EF;
using MozaeekCore.RestAPI.Bootstrap;
using MozaeekCore.RestAPI.Utility;

namespace MozaeekCore.RestAPI
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
            services.AddCors(options => options.AddPolicy("ApiCorsPolicy", builder =>
            {
                builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod().AllowAnyHeader()
                    .WithExposedHeaders("Token-Expired");
            }));
            services.AddFrameworkServices();
            services.AddCommandHandlerServices();
            services.AddQueryHandlerServices();
            services.AddAuthorizationServices(this.Configuration);

            services.AddDbContext<CoreDomainContext>(options =>
                options.UseInMemoryDatabase(databaseName: "CoreDomainContext"));
            
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IHttpContextAccessor, HttpContextAccessor>();
            services.AddControllers();
            services.AddScoped<CurrentUser>(provider =>
            {
                var claims = provider.GetService<IHttpContextAccessor>().HttpContext.User.Claims;
                var userIdClaim = claims.SingleOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
                string userId = "";
                if (userIdClaim != null)
                {
                    userId = userIdClaim.Value;
                }
                var userNameClaim = claims.SingleOrDefault(c => c.Type == ClaimTypes.Name);
                string userName = "";
                if (userNameClaim != null)
                {
                    userName = userNameClaim.Value;
                }
                var currentUser = new CurrentUser();
                currentUser.UserId = userId;
                currentUser.UserName = userName;
                return currentUser;
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MozaeekCore.RestAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("ApiCorsPolicy");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MozaeekCore.RestAPI v1"));
            }

            app.UseHttpsRedirection();
            // app.UseExceptionHandler("/error");
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
