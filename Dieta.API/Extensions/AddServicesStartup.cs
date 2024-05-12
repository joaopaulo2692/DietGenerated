using Dieta.Core.Interfaces.Repository;
using Dieta.Core.Interfaces.Service;
using Dieta.Infrastructure.Repository;
using Dieta.Infrastructure.Service;

namespace Dieta.API.Extensions
{
    public static class AddServicesStartup
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {

            services.AddScoped<IFoodService, FoodService>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
