using System;

using BackgroundJobs.Abstract;
using BackgroundJobs.Concrete;
using Business.Abstract;
using Business.Concrete;
using Business.Configuration.Cache;
using Business.Configuration.Filters.Exeption;
using Business.Configuration.Filters.Logs;
using Business.Configuration.Filters.Validation;
using Business.Configuration.Mapper;
using Bussines.Abstract;
using Bussines.Concrete;
using DAL.Abstract;
using DAL.Concrete.EF;
using DAL.Concrete.Mongo;
using DAL.DbContexts;
using Hangfire;
using Hangfire.SqlServer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;
using StackExchange.Redis;

namespace PaymentService
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

            services.AddControllers(opt =>
            {

                opt.Filters.Add<ValidationFilter>();
                opt.Filters.Add<ExceptionFilter>();






            });
            services.AddAutoMapper(config =>
            config.AddProfile(new MapperProfile()));
            // services.AddDbContext<ManagementDbContext>(ServiceLifetime.Transient);

            services.AddDbContext<ManagementDbContext>(opt =>
            {
                opt.EnableSensitiveDataLogging();

            });


            var redisConfigInfo = Configuration.GetSection("RedisEndpointInfo").Get<RedisEndpointInfo>();
            services.AddStackExchangeRedisCache(opt =>
            {
                opt.ConfigurationOptions = new ConfigurationOptions()
                {
                    EndPoints =
                    {
                        { redisConfigInfo.EndPoint, redisConfigInfo.Port }
                    },
                    Password = redisConfigInfo.Password,
                    User = redisConfigInfo.UserName

                };
            });
            services.AddSingleton<MongoClient>(x => new MongoClient("mongodb+srv://admin:admin@cluster0.8p4bqdo.mongodb.net/?retryWrites=true&w=majority"));
            services.AddScoped<IUserRepository, EFUserRepository>();
            services.AddScoped<IApartmentRepository, EFApartmentRepository>();
            services.AddScoped<IBillRepository, EFBillRepository>();
            services.AddScoped<IVoucherRepository, VoucherRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IApartmentService, ApartmentService>();
            services.AddScoped<IBillService, BillService>();
            services.AddScoped<ICacheService, CacheService>();
            services.AddScoped<IVoucherService, VoucherService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<MsSqlLogger>();
            services.AddScoped<IJobs, Jobs>();
            services.AddScoped<ISendMailService, SendMailService>();

            var hangFireDb = Configuration.GetConnectionString("HangfireConnection");

            services.AddHangfire(configuration => configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseSqlServerStorage(hangFireDb, new SqlServerStorageOptions
                {
                    CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                    SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                    QueuePollInterval = TimeSpan.Zero,
                    UseRecommendedIsolationLevel = true,
                    DisableGlobalLocks = true
                }));

            services.AddHangfireServer();



            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApi", Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApi v1"));
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
