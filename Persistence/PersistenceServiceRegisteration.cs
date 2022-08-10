using Application.Contracts.Repositories;
using Application.Contracts.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public static class PersistenceServiceRegisteration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RayaTaskDBContext>(options => 
                options.UseSqlServer(configuration.GetConnectionString("RayaTaskConnectionString")));

            services.AddScoped(typeof(IGenericRepo<>), typeof(GenericRepo<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IPersonRepo, PersonRepo>();
            services.AddScoped<IAddressRepo, AddressRepo>();



            services.AddScoped<IPersonService, PersonService>();
            return services;
        }
    }
}
