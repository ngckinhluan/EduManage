
using EduManage.API.Extensions;
using FluentValidation;
using FluentValidation.AspNetCore;
using SwaggerThemes;
using System.ComponentModel.DataAnnotations;
using EduManage.BusinessObjects.Context;
using EduManage.Validations;
using Microsoft.EntityFrameworkCore;

namespace EduManage.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container.
            //builder.Services.AddControllers();
            builder.Services.AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(builder.Configuration.GetConnectionString("eStore"));
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

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
