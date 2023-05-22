using Infrastructure.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database
{
    public static class ServiceRegistration
    {
        public static void AddDatabaseInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<CQRSFootballLeagueDBContext>(options =>
            {
                options.UseSqlServer(config["ConnectionString"]);
            }, ServiceLifetime.Scoped);
        }
    }
}
