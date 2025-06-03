using BakoraAPI.Contracts;
using BakoraAPI.Entities.ConfigurationModels;
using BakoraAPI.Entities.Entities;
using BakoraAPI.Repository;
using BakoraAPI.Services;
using BakoraAPI.Services.Contracts;
using BakoraAPI.Shared.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Globalization;
using System.Text;

namespace BakoraAPI.Extensions;

public static class ServiceExtension
{
    // CORS Configuration
    public static void ConfigureCors(this IServiceCollection services) =>
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder =>
            builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            .WithExposedHeaders("X-Pagination"));
        });

    // Configure Sql Connection
    public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
        services.AddDbContext<RepositoryContext>(opts =>
        //opts.UseSqlServer(configuration.GetConnectionString("sqlConnection")));
             opts.UseSqlServer(configuration.GetConnectionString("smarterConnection"),
    sqlOptions => sqlOptions.EnableRetryOnFailure()));
    // Configure Identity
    public static void ConfigureIdentity(this IServiceCollection services)
    {
        var builder = services.AddIdentity<User, IdentityRole<Guid>>(o =>
        {
            o.Password.RequireDigit = true;
            o.Password.RequireLowercase = true;
            o.Password.RequireUppercase = true;
            o.Password.RequireNonAlphanumeric = true;
            o.Password.RequiredLength = 10;
            o.User.RequireUniqueEmail = true;
        })
            .AddEntityFrameworkStores<RepositoryContext>()
            .AddDefaultTokenProviders();
    }

    // Configure JWT
    public static void ConfigureJWT(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtConfiguration = new JwtConfiguration();
        configuration.Bind(jwtConfiguration.Section, jwtConfiguration);

        // var secretKey = Environment.GetEnvironmentVariable("SECRET"); WHEN I CAN MAKE AN E VARIABLE ON THE SERVER

        services.AddAuthentication(opt =>
        {
            opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,

                ValidIssuer = jwtConfiguration.ValidIssuer,
                ValidAudience = jwtConfiguration.ValidAudience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfiguration.SecretKey)),

                ClockSkew = TimeSpan.Zero
            };
        });
    }

    // Configure JwtConfiguration Class
    public static void AddJwtConfiguratonClass(this IServiceCollection services, IConfiguration configuration) =>
        services.Configure<JwtConfiguration>(configuration.GetSection("JwtSettings"));

    // Configure Repository Manager
    public static void ConfigureRepositoryMaager(this IServiceCollection services) =>
        services.AddScoped<IRepositoryManager, RepositoryManager>();

    // Configure Service Manager 
    public static void ConfigureServiceManager(this IServiceCollection services) =>
        services.AddScoped<IServiceManager, ServiceManager>();

    // Configure Authentication Service Manager
    public static void ConfigureAuthenticationServiceManager(this IServiceCollection services) =>
        services.AddScoped<IAuthenticationServiceManager, AuthenticationServiceManager>();

    // Configure Localization
    public static void ConfigureLocalization(this IServiceCollection services) =>
        services.Configure<RequestLocalizationOptions>(options =>
        {
            var supportedCultures = new[] { new CultureInfo("en"), new CultureInfo("ar") };

            options.DefaultRequestCulture = new RequestCulture("en");
            options.SupportedCultures = supportedCultures;
            options.SupportedUICultures = supportedCultures;
        });

    // Configure Validators
    public static void ConfigureValidators(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation();

        // Register all the Validators
        services.AddValidatorsFromAssemblyContaining<AdminRegisterDtoValidator>();
        services.AddValidatorsFromAssemblyContaining<AdminUpdateDtoValidator>();
        services.AddValidatorsFromAssemblyContaining<LoginUserDtoValidator>();
        services.AddValidatorsFromAssemblyContaining<ProviderRegisterDtoValidator>();
        services.AddValidatorsFromAssemblyContaining<ProviderUpdateDtoValidator>();
        services.AddValidatorsFromAssemblyContaining<RequesterUpdateDtoValidator>();
        services.AddValidatorsFromAssemblyContaining<RequesterRegisterDtoValidator>();
        services.AddValidatorsFromAssemblyContaining<ServiceUpdateDtoValidator>();
        services.AddValidatorsFromAssemblyContaining<ServiceCreateDtoValidator>();
    }
}
