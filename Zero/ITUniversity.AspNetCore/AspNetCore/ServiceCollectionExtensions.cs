﻿using System;
using System.Linq;
using System.Reflection;

using ITUniversity.AspNetCore.Mvc.Conventions;
using ITUniversity.AspNetCore.Mvc.Providers;
using ITUniversity.AspNetCore.Runtime.Session;
using ITUniversity.Runtime.Session;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace ITUniversity.AspNetCore
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            var applicationPartManager = services.GetSingletonServiceOrNull<ApplicationPartManager>();
            applicationPartManager?.FeatureProviders.Add(new AppServiceControllerFeatureProvider());

            services.Configure<MvcOptions>(mvcOptions =>
            {
                mvcOptions.Conventions.Add(new AppServiceConvention(services));
            });

            services.TryAddSingleton<IAppSession, ClaimsAppSession>();
            services.TryAddSingleton<IPrincipalAccessor, AspNetCorePrincipalAccessor>();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            return services;
        }

        public static IServiceCollection CreateControllersForAppServices(this IServiceCollection services, Assembly assembly)
        {
            var applicationPartManager = services.GetSingletonServiceOrNull<ApplicationPartManager>();
            applicationPartManager?.ApplicationParts.Add(new AssemblyPart(assembly));

            return services;
        }

        public static T GetSingletonServiceOrNull<T>(this IServiceCollection services)
        {
            return (T)services
                .FirstOrDefault(d => d.ServiceType == typeof(T))
                ?.ImplementationInstance;
        }

        public static T GetSingletonService<T>(this IServiceCollection services)
        {
            var service = services.GetSingletonServiceOrNull<T>();
            if (service == null)
            {
                throw new Exception("Can not find service: " + typeof(T).AssemblyQualifiedName);
            }
            return service;
        }
    }
}