
using Dieta.Core.Interfaces.Repository;
using Dieta.Infrastructure.Repository;

namespace Dieta.API.Extensions
{
    public static class AddRepositoriesStartup
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddSingleton<IFoodRepository, FoodRepository>();

            return services;
        }
    }
}
