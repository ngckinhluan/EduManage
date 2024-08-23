
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
                options.UseNpgsql(builder.Configuration.GetConnectionString("eStore"));
            });
            
            // Configure JwtSettings
            builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));
            
            builder.Services.AddAuthentication(opt => {
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
                        ValidIssuer = "https://localhost:5173",
                        ValidAudience = "https://localhost:5173",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]))
                    };
                });
            
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
            builder.Services.AddSwaggerGen();
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
