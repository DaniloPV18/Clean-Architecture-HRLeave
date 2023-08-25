using HRLeaveManagment.Application.Contracts.Persistence;
using HRLeaveManagment.Persistence.DatabaseContext;
using HRLeaveManagment.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HRLeaveManagment.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection _services, IConfiguration _configuration)
        {
            _services.AddDbContext<HRDatabaseContext>( options =>
            {
                options.UseSqlServer(_configuration.GetConnectionString("HrDatabaseConnectionString"));
            });
            _services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
            _services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();
            _services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();
            _services.AddScoped<ILeaveAllocationRepository, LeaveAllocationRepository>();
            return _services;
        }
    }
}
