using CustomMediatr.Library.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CustomMediatr.Library
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddCustomMediator(this IServiceCollection services, Assembly[] assemblies)
        {
            var types = assemblies.SelectMany(i => i.GetTypes()).Where(i =>!i.IsInterface);

            var requestHandlers = types
                .Where(i => IsAssignableToGenericType(i, typeof(IRequestHandler<,>)))
                .ToList();

            foreach (var handler in requestHandlers)
            {
                var handlerInterface = handler.GetInterfaces().FirstOrDefault();
                var requestType = handlerInterface.GetGenericArguments()[0]; // query qismi
                var responseType = handlerInterface.GetGenericArguments()[1]; // viewmodel qismi

                var genericType = typeof(IRequestHandler<,>).MakeGenericType(requestType, responseType);


                services.AddTransient(genericType, handler);
            }

            services.AddSingleton<IMediator, Mediator>();

            return services;

           // services.AddTransient<IRequestHandler<GetUserByIdQuery, UserViewModel>, GetUserByIdQueryHandler>();

        }

        public static IServiceProvider UseCustomMediator(this IServiceProvider serviceProvider)
        {
            ServiceProvider.SetInstance(serviceProvider);
            return serviceProvider; 
        }

        /// <summary>
        /// Find out if a class derives from an interface we specify
        /// </summary>
        /// <param name="givenType">The type we send to check</param>
        /// <param name="genericType">The type that we want to learn is generic</param>
        /// <returns>Boolean if find "true" or didn't find "false"</returns>
        private static bool IsAssignableToGenericType(Type givenType, Type genericType)
        {
            bool isGeneric(Type _givenType, Type _genericType)
            {
                return _givenType.IsGenericType && _givenType.GetGenericTypeDefinition() == _genericType;
            }

            var interfaceTypes = givenType.GetInterfaces();

            foreach (var it in interfaceTypes)
            {
                if (isGeneric(it, genericType))
                    return true;
            }

            if (isGeneric(givenType, genericType))
                return true;

            Type baseType = givenType.BaseType;

            if (baseType is null)
                return false;

            return IsAssignableToGenericType(baseType,genericType); 
        }
    }
}
