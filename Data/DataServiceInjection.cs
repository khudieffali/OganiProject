using Data.DataContexts;
using Infrastructure.Commons.Abstracts;
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

            var repoInterfaceType = typeof(IRepository<>);
            var concreteRepositoryAssembly = typeof(DataServiceInjection).Assembly;
            var repoPairs = repoInterfaceType.Assembly
                .GetTypes()
                .Where(x => x.IsInterface && x.GetInterfaces().Any(y => y.IsGenericType && y.GetGenericTypeDefinition() == repoInterfaceType))
                .Select(x => new
                {
                    AbstractRepo = x,
                    ConcreteRepo = concreteRepositoryAssembly.GetTypes().FirstOrDefault(z => z.IsClass && x.IsAssignableFrom(z))
                })
                .Where(x => x.ConcreteRepo != null);
            foreach (var item in repoPairs)
            {
                services.AddScoped(item.AbstractRepo, item.ConcreteRepo!);
            }
            return services;
        }

    }
}
