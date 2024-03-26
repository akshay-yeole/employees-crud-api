using EMS.Core.Data;
using EMS.Core.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EMS.Core
{
    public static class ServiceExtensions
    {
        public static void AddCoreServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddDbContext<AppDbContext>(option => option.UseSqlServer(configuration.GetConnectionString("Default")));
        }
    }
}
