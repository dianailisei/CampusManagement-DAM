using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace UCM.Business
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBusiness(this IServiceCollection services, IConfiguration configuration)
        {
            // FluentValidation services area //


            // AutoMapper services area //
            var config = new AutoMapper.MapperConfiguration(c =>
            {
                c.AddProfile(new ApplicationProfile());
            });

            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            // Business services area //

            return services;
        }
    }
}
