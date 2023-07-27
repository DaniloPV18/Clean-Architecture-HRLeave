using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace HRLeaveManagment.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection _services)
        {
            _services.AddAutoMapper(Assembly.GetExecutingAssembly());
            _services.AddMediatR(Assembly.GetExecutingAssembly());
            return _services;
        }
    }
}
