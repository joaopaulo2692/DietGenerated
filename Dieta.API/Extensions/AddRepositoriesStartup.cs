
using Dieta.Core.Interfaces.Repository;
using Dieta.Core.Interfaces.Service;
using Dieta.Infrastructure.Repository;
using Dieta.Infrastructure.Service;

namespace Dieta.API.Extensions
{
    public static class AddRepositoriesStartup
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IFoodRepository, FoodRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IDietRepository, DietRepository>();
            services.AddScoped<IMealRepository, MealRepository>();

          

            return services;
        }
    }
}
