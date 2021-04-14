using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace VH.Currency
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddCurrencyService(this IServiceCollection services)
        {
            services.AddScoped<ICurrencyService, CurrencyService>();
            return services;

        }

    }
}
