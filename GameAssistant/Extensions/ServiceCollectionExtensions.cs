using GameAssistant.Interfaces;
using GameAssistant.Services;
using Microsoft.Extensions.DependencyInjection;

namespace GameAssistant.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureGameAssistant<T>(this IServiceCollection services, T gameStateProvider) where T : class, IGameStateProvider
        {
            return services
                .AddTransient<ITurnTracker, TurnTracker>()
                .AddTransient<IGameStateProvider, T>(provider => gameStateProvider)
                .AddTransient<IGameStateService, GameStateService>();
        }
    }
}
