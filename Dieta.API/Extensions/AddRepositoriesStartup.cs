using Dieta.API.Interfaces;
using Dieta.API.Repository;

namespace Dieta.API.Extensions
{
    public static class AddRepositoriesStartup
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddSingleton<IFoodRepository, AlimentoRepository>();

            return services;
        }
    }
}
