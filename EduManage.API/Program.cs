
using EduManage.API.Extensions;
using FluentValidation;
using FluentValidation.AspNetCore;
using SwaggerThemes;
using System.ComponentModel.DataAnnotations;
using System.Text;
using EduManage.BusinessObjects.Context;
using EduManage.BusinessObjects.Settings;
using EduManage.Services.Helpers;
using EduManage.Services.Implementation;
using EduManage.Services.Interface;
using EduManage.Validations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace EduManage.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container.
            //builder.Services.AddControllers();
            ConfigurationManager configuration = builder.Configuration;
            builder.Services.AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("edumanage"));
            });
            
            // Configure JwtSettings
            builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));
            
            
            
            #region Authorization-Authentication
            builder.Services.AddAuthorization();
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
                    ValidAudience = builder.Configuration["JwtSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey
                        (Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Key"] ?? "")),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true,
                };
            });
            #endregion
            
            #region Fluent Validation
            builder.Services.AddFluentValidationClientsideAdapters();
            builder.Services.AddValidatorsFromAssemblyContaining<CourseRequestDtoValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<EnrollmentRequestDtoValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<StudentRequestDtoValidator>();
            #endregion
            builder.Services.AddFluentValidationAutoValidation();
          
            builder.Services.AddAutoMapper(typeof(Program));
            builder.Services.AddScopeService();
            builder.Services.AddSingleton(sp => sp.GetRequiredService<IOptions<JwtSettings>>().Value);
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            #region Swagger
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Clean API", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                    Description = "Please insert JWT with Bearer into field",
                    Name = "Authorization",
                    Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "bearer"
                });
                c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement{
                    {
                        new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                        {
                            Reference = new Microsoft.OpenApi.Models.OpenApiReference
                            {
                                Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });
            #endregion
            var app = builder.Build();

            #region Swagger
            app.UseSwagger();
            // Swagger dark theme using SwaggerThemes installed from NuGet Package Management.
            app.UseSwaggerThemes(Theme.Dracula);
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "EduManage-API-V1");
                c.RoutePrefix = "swagger";
            });
           


            #endregion
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseAuthentication(); 
            app.UseAuthorization();
            app.MapControllers(); 
            app.Run();
        }
    }
}
