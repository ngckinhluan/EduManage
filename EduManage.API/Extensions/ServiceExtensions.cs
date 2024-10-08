﻿using EduManage.BusinessObjects.DTOs.Request;
using EduManage.DAOs;
using EduManage.Repositories.Implementation;
using EduManage.Repositories.Interface;
using EduManage.Services.Helpers;
using EduManage.Services.Implementation;
using EduManage.Services.Interface;


namespace EduManage.API.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddScopeService(this IServiceCollection serviceCollection)
        {
            #region DAOs
            serviceCollection.AddScoped<CourseDao>();
            serviceCollection.AddScoped<StudentDao>();
            serviceCollection.AddScoped<EnrollmentDao>();
            serviceCollection.AddScoped<LecturerDao>();
            serviceCollection.AddScoped<LecturerCourseDao>();
            serviceCollection.AddScoped<RoleDao>();
            #endregion

            #region Repositories
            serviceCollection.AddScoped<ICourseRepository, CourseRepository>();
            serviceCollection.AddScoped<IStudentRepository, StudentRepository>();
            serviceCollection.AddScoped<IEnrollmentRepository, EnrollmentRepository>();
            serviceCollection.AddScoped<ILecturerRepository, LecturerRepository>();
            serviceCollection.AddScoped<ILecturerCourseRepository, LecturerCourseRepository>();
            serviceCollection.AddScoped<IRoleRepository, RoleRepository>();
            #endregion

            #region Services
            serviceCollection.AddScoped<ICourseService, CourseService>();
            serviceCollection.AddScoped<IStudentService, StudentService>();
            serviceCollection.AddScoped<IEnrollmentService, EnrollmentService>();
            serviceCollection.AddScoped<ILecturerService, LecturerService>();
            serviceCollection.AddScoped<ILecturerCourseService, LecturerCourseService>();
            serviceCollection.AddScoped<IAuthService, AuthService>();
            serviceCollection.AddScoped<GenerateJWT>();
            serviceCollection.AddScoped<IRoleService, RoleService>();
            #endregion

            return serviceCollection;
        }
    }
}
