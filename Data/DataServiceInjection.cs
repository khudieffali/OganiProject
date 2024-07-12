using Data.DataContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public static class DataServiceInjection
    {
        public static IServiceCollection DataServices(this IServiceCollection services, IConfiguration config)
        {
            var connectString = config.GetConnectionString("OganiDB");
            services.AddDbContext<DbContext, OganiDataContext>(cfg =>
            {
                cfg.UseSqlServer(connectString,
                   options =>
                  {
                      options.MigrationsHistoryTable("Migrations");
                  });
            });
            return services;
        }
    }
}
