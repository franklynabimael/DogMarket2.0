using Dog_Market_2._0;
using Dog_Market_2._0.JwtFeatures;
using Dog_Market_2._0.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;

namespace WebApi;

public static class Program
{
    private const string SqlConnectionString = "SqlServerConnection";
    public static void Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);

        AddSwagger(builder);
        AddIdentity(builder.Services, builder.Configuration);
        AddJwtTokenAuthentication(builder.Services, builder.Configuration);

        builder.Services.AddDbContext<DogMarketContext>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString(SqlConnectionString)));
        builder.Services.AddControllers();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddScoped<JwtHandler>();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseRouting();
        app.MapControllers();
        app.UseAuthentication();
        app.UseAuthorization();

        using var serviceScope = app.Services.CreateScope();
        using var context = serviceScope.ServiceProvider.GetService<DogMarketContext>();
        context.Database.Migrate();

        app.Run();
    }

    private static void AddSwagger(WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            var securityScheme = new OpenApiSecurityScheme
            {
                Name = "JWT Authentication",
                Description = "Enter JWT Bearer token **_only_**",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT",
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            };
            c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
            c.AddSecurityRequirement(
                new OpenApiSecurityRequirement { { securityScheme, Array.Empty<string>() } }
            );
        });
    }

    private static void AddJwtTokenAuthentication(IServiceCollection services, ConfigurationManager configuration)
    {
        var jwtSettings = configuration.GetSection("JwtSettings");
        services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings["validIssuer"],
                    ValidAudience = jwtSettings["validAudience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                        .GetBytes(jwtSettings.GetSection("securityKey").Value))
                };
            });
        }

    private static void AddIdentity(IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddIdentity<User, IdentityRole>(opts =>
        {
            opts.Password.RequiredLength = 6;
            opts.Password.RequireDigit = false;
            opts.Password.RequiredUniqueChars = 0;
            opts.Password.RequireLowercase = false;
            opts.Password.RequireNonAlphanumeric = false;
            opts.Password.RequireUppercase = false;
            opts.SignIn.RequireConfirmedEmail = false;
            opts.User.RequireUniqueEmail = true;
            opts.Lockout.AllowedForNewUsers = true;
        })
            .AddEntityFrameworkStores<DogMarketContext>()
            .AddDefaultTokenProviders();
    }
}