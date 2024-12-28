using DAL.Repositories.Implementations;
using DAL.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class DALServiceRegistrations
    {
        public static void AddDALServices(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
        }
    }
}
