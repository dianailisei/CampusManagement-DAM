using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using FluentValidation.AspNetCore;
using UCM.Business.Authentication;
using UCM.Business.Helpers;
using UCM.Business.Person;
using UCM.Business.Person.Models;
using UCM.Business.Person.Validations;
using UCM.Business.Student;
using UCM.Business.Student.Models;
using UCM.Business.Student.Validations;

namespace UCM.Business
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBusiness(this IServiceCollection services, IConfiguration configuration)
        {
            // FluentValidation services area //
            services.AddMvc().AddFluentValidation(fv => {
                fv.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
                fv.ImplicitlyValidateChildProperties = true;
            });

            services.AddTransient<IValidator<PersonCreateModel>, PersonCreateModelValidator>();

            services.AddTransient<IValidator<StudentCreateModel>, StudentCreateModelValidator>();
            services.AddTransient<IValidator<IEnumerable<StudentCreateModel>>,
                StudentCreateModelCollectionValidator>();

            // AutoMapper services area //
            var config = new AutoMapper.MapperConfiguration(c =>
            {
                c.AddProfile(new ApplicationProfile());
            });

            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            // Business services area //
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IPersonService, PersonService>();

            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddSingleton<IPasswordHasher, PasswordHasher>();

            return services;
        }
    }
}
