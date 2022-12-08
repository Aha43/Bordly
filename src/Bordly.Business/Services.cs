using Bordly.Business.ViewController;
using Bordly.Business.ViewModel;
using Bordly.Infrastructure.Api.InMemory;
using Bordly.Specification.Api;
using Microsoft.Extensions.DependencyInjection;

namespace Bordly.Business
{
    public static class Services
    {
        public static IServiceCollection AddBordlyServices(this IServiceCollection services)
        {
            return services.AddSingleton<IGameApi, InMemoryGameApi>()
                .AddSingleton<ViewModelFactory>()
                .AddViewControllers();
        }

        private static IServiceCollection AddViewControllers(this IServiceCollection services)
        {
            return services.AddSingleton<PlayerViewController>()
                .AddSingleton<GameViewController>()
                .AddSingleton<GamesViewController>();
        }

    }
}
