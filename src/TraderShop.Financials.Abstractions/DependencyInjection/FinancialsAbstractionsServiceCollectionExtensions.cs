using Microsoft.Extensions.DependencyInjection;
using TraderShop.Financials.Abstractions.Services;
using TraderShop.Financials.Abstractions.Services.Impl;

namespace TraderShop.Financials.Abstractions.DependencyInjection
{
    public static class FinancialsAbstractionsServiceCollectionExtensions
    {
        public static IServiceCollection AddFinancialsAbstractionsServices(
            this IServiceCollection services)
        {
            services.AddSingleton<IErrorHandler, ErrorHandler>();

            return services;
        }
    }
}
