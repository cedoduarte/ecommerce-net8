using AutoMapper;
using ecommerce.Enums;
using ecommerce.Middlewares;
using ecommerce.Models;
using ecommerce.Models.Interface;
using ecommerce.Services;
using ecommerce.Services.Interface;
using ecommerce.Shared;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text.Json.Serialization;

namespace ecommerce
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DatabaseTypeGetter.DbEngine = DatabaseEngine.MySql;
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });
            builder.Services.AddSingleton<IConfiguration>(options =>
            {
                string environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
                var configurationBuilder = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json")
                    .AddJsonFile("appsettings.Local.json", true)
                    .AddEnvironmentVariables();
                return configurationBuilder.Build();
            });
            builder.Services.Configure<IISServerOptions>(options =>
            {
                options.MaxRequestBodySize = int.MaxValue;
            });
            builder.Services.Configure<FormOptions>(options =>
            {
                options.ValueLengthLimit = int.MaxValue;
                options.MultipartBodyLengthLimit = int.MaxValue;
                options.MultipartHeadersLengthLimit = int.MaxValue;
            });
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(builder.Configuration["ApiVersion"], new OpenApiInfo()
                {
                    Version = builder.Configuration["ApiVersion"],
                    Title = builder.Configuration["ApiTitle"],
                    Description = builder.Configuration["ApiDescription"],
                    TermsOfService = new Uri(builder.Configuration["ApiTermsOfServiceUrl"]),
                    Contact = new OpenApiContact()
                    {
                        Name = builder.Configuration["ApiContactName"],
                        Url = new Uri(builder.Configuration["ApiContactUrl"])
                    },
                    License = new OpenApiLicense()
                    {
                        Name = builder.Configuration["ApiLicense"],
                        Url = new Uri(builder.Configuration["ApiLicenseUrl"])
                    }
                });
            });
            builder.Services.AddTransient<IAppDbContext, AppDbContext>();
            builder.Services.AddTransient<IUserService, UserService>();
            builder.Services.AddTransient<IProductService, ProductService>();
            builder.Services.AddSingleton(new MapperConfiguration(configuration =>
            {
                configuration.AddProfile(new MappingProfile());
            }).CreateMapper());
            builder.Services.AddMediatR(configurationBinder =>
            {
                configurationBinder.RegisterServicesFromAssembly(typeof(Program).Assembly);
            });
            string dbConnectionString = builder.Configuration.GetConnectionString("ecommerce");
            builder.Services.AddDbContext<IAppDbContext, AppDbContext>(options =>
            {
                options.UseMySql(dbConnectionString, ServerVersion.AutoDetect(dbConnectionString), sqlOptions =>
                {
                    sqlOptions.MigrationsAssembly(typeof(AppDbContext).GetTypeInfo().Assembly.GetName().Name);
                });
            });
            builder.Services.AddMvc();
            var app = builder.Build();
            using (IServiceScope scope = app.Services.CreateScope())
            {
                try
                {
                    AppDbContext dbContext = (AppDbContext)scope.ServiceProvider.GetService<IAppDbContext>();
                    dbContext.Database.Migrate();
                    DbSeeder.DoSeeding(dbContext);
                }
                catch (Exception ex)
                {
                    ILogger<Program> logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while migrating or initializing the database");
                }
            }
            app.UseCors(options =>
                options.AllowAnyOrigin()
                       .AllowAnyHeader()
                       .AllowAnyMethod());
            app.UseStaticFiles();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint(builder.Configuration["ApiSwaggerEndpoint"], builder.Configuration["ApiVersion"]);
                });
            }
            app.UseHttpsRedirection();
            app.UseTokenAuthentication(builder.Configuration["AuthorizationToken"]);
            //app.UseCustomMiddleware("custom-header-value");
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}