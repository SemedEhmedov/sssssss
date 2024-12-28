using Business.Services.Implementations;
using Business.Services.Interfaces;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public static class ServiceRegistrations
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ServiceRegistrations));
            services.AddScoped<IProductService,ProductService>();
            services.AddControllers().AddFluentValidation(c=>c.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));
        }
    }
}
