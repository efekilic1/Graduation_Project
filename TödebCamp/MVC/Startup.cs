using Business.Abstract;
using Business.Concrete;
using DAL.Concrete.EF;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Business.Configuration.Auth;
using DAL.DbContexts;
using DAL.Abstract;
using Business.Configuration.Mapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace MVC
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

            services.AddControllersWithViews();

            services.AddDbContext<ManagementDbContext>(ServiceLifetime.Transient);


            services.AddAutoMapper(config =>
            config.AddProfile(new MapperProfile()));


            services.AddScoped<IUserRepository, EFUserRepository>();
            services.AddScoped<IApartmentRepository, EFApartmentRepository>();
            services.AddScoped<IBillRepository, EFBillRepository>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IApartmentService, ApartmentService>();
            services.AddScoped<IBillService, BillService>();
            services.AddScoped<ICacheService, CacheService>();



            var tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = tokenOptions.Issuer,
                        ValidAudience = tokenOptions.Audience,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions.SecurityKey))
                    };
                });












        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseSession();
            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

         
                app.UseEndpoints(Endpoint 
                {
                        endpoints.MapControllerRoute(
                        name: "default",
                        pattern: "{controller=Books}/{action=Details}/{id?}");
                });


            
        }
    }
}
