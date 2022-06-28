using Microsoft.Extensions.DependencyInjection;
using IMS.Core.Interfaces.Repositories;
using IMS.Core.Interfaces.Services;
using IMS.Infrastructure.Repositories;
using IMS.ServiceInterface;

namespace IMS.WebApi
{
    public static class ServiceCollectionSetup
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IIncidentService, IncidentService>();
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IIncidentRepository, IncidentRepository>();

        }

    }
}

