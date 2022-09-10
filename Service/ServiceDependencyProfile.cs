using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Service.Services;
using ServiceInterface.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ServiceDependencyProfile
    {

        public static void Register(IConfiguration configuration, IServiceCollection services)
        {
            services.AddScoped<IProfileService, ProfileService>();
            services.AddScoped<IDbService, DbService>();
        }
    }
}
