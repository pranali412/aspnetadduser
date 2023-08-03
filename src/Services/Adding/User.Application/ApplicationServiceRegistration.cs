using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using User.Application.Services;

namespace User.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {


            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddTransient<IUserService, UserService>();


            return services;
        }
    }
}
