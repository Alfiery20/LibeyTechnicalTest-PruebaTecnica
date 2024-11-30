﻿using LibeyTechnicalTestDomain.LibeyUserAggregate.Application;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Infrastructure;
namespace LibeyTechnicalTestAPI.Middleware
{
    public static class DIExtensions
    {
        public static IServiceCollection AddConfigurations(this IServiceCollection services)
        {
            services.AddTransient<ILibeyUserAggregate, LibeyUserAggregate>();
            services.AddTransient<ILibeyUserRepository, LibeyUserRepository>();

            services.AddTransient<ILocationRepository, LocationRepository>();
            services.AddTransient<ILocateAggregate, LocateAggregate>();

            services.AddTransient<ITypeDocumentRepository, TypeDocumentRepository>();
            services.AddTransient<ITypeDocumentAggregate, TypeDocumentAggregate>();


            return services;
        }
    }
}



