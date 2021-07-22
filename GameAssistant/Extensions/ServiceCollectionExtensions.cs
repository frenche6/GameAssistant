using GameAssistant.Interfaces;
using GameAssistant.Services;
using Microsoft.Extensions.DependencyInjection;

namespace GameAssistant.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureGameAssistant<TStateProvider, TTurnTracker>(
            this IServiceCollection services, TStateProvider gameStateProvider, TTurnTracker turnTracker)
            where TStateProvider : class, IGameStateProvider
            where TTurnTracker : class, ITurnTracker
        {
            return services
                .AddTransient<ITurnTracker, TTurnTracker>(tracker => turnTracker)
                .AddTransient<IGameStateProvider, TStateProvider>(provider => gameStateProvider)
                .AddTransient<IGameStateService, GameStateService>();
        }
    }
}
