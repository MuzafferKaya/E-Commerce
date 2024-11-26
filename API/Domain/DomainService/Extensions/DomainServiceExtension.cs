﻿using DomainService.Products;
using Microsoft.Extensions.DependencyInjection;

namespace DomainService.Extensions
{
    public static class DomainServiceExtension
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            return services;
        }
    }
}